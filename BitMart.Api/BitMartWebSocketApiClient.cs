namespace BitMart.Api;

/// <summary>
/// BitMart WebSocket Client
/// </summary>
public class BitMartWebSocketApiClient : WebSocketApiClient
{
    /// <summary>
    /// BitMart Spot WebSocket Client
    /// </summary>
    public BitMartWebSocketApiSpotClient Spot { get; }

    /// <summary>
    /// BitMart Futures WebSocket Client
    /// </summary>
    public BitMartWebSocketApiFuturesClient Futures { get; }

    /// <summary>
    /// Creates a new instance of BitMartWebSocketClient
    /// </summary>
    public BitMartWebSocketApiClient() : this(null, new BitMartWebSocketApiClientOptions())
    {
    }

    /// <summary>
    /// Creates a new instance of BitMartWebSocketClient
    /// </summary>
    /// <param name="options"></param>
    public BitMartWebSocketApiClient(BitMartWebSocketApiClientOptions options) : this(null, options)
    {
    }

    /// <summary>
    /// Creates a new instance of BitMartWebSocketClient
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="options"></param>
    public BitMartWebSocketApiClient(ILogger logger, BitMartWebSocketApiClientOptions options) : base(logger, options)
    {
        ContinueOnQueryResponse = true;
        UnhandledMessageExpected = true;
        KeepAliveInterval = TimeSpan.Zero;

        Spot = new BitMartWebSocketApiSpotClient(this);
        Futures = new BitMartWebSocketApiFuturesClient(this);

        IgnoreHandlingList = ["pong"];
        SendPeriodic("PING", TimeSpan.FromSeconds(5), conn => "ping");
    }

    #region Public Methods
    /// <summary>
    /// Set API Credentials
    /// </summary>
    /// <param name="key">API Key</param>
    /// <param name="secret">API Secret</param>
    /// <param name="memo">Memo</param>
    public void SetApiCredentials(string key, string secret, string memo)
        => base.SetApiCredentials(new BitMartApiCredentials(key, secret, memo));
    #endregion

    #region Overrided Methods
    /// <inheritdoc/>
    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
        => new BitMartAuthenticationProvider((BitMartApiCredentials)credentials);

    /// <inheritdoc/>
    protected override async Task<CallResult<bool>> AuthenticateAsync(WebSocketConnection connection)
    {
        if (this.AuthenticationProvider == null)
            return new CallResult<bool>(new NoApiCredentialsError());

        var timestamp = DateTime.UtcNow.ConvertToMilliseconds();
        var key = this.AuthenticationProvider.Credentials.Key!.GetString();
        var memo = ((BitMartApiCredentials)(this.AuthenticationProvider.Credentials)).Memo;
        var signtext = $"{timestamp}#{memo}#bitmart.WebSocket";
        var signature = ((BitMartAuthenticationProvider)this.AuthenticationProvider).StreamApiSignature(signtext);

        var request = new BitMartWebSocketRequest();

        // Spot WebSocket
        if (connection.Tag.Contains("ws-manager-compress.bitmart.com"))
        {
            request.Operation = "login";
            request.Parameters = [key, timestamp.ToString(), signature];
        }

        // Futures WebSocket
        else if (connection.Tag.Contains("openapi-ws-v2.bitmart.com"))
        {
            request.Action = "access";
            request.Parameters = [key, timestamp.ToString(), signature, "web"];
        }

        // JSON
        var json = JsonConvert.SerializeObject(request);

        var result = false;
        await connection.SendAndWaitAsync(request, ClientOptions.ResponseTimeout, data =>
        {
            // Check Point
            if (data.Type != JTokenType.Object)
                return false;

            // Spot WebSocket
            if (data["event"] != null)
                result = (string)data["event"] == "login";

            // Futures WebSocket
            if (data["action"] != null && data["success"] != null)
                result = (string)data["action"] == "access" && (bool)data["success"];

            // Return
            return result;
        });

        return result
            ? new CallResult<bool>(result)
            : new CallResult<bool>(new ServerError("Unspecified Error"));
    }

    /// <inheritdoc/>
    protected override bool HandleQueryResponse<T>(WebSocketConnection connection, object request, JToken data, out CallResult<T> callResult)
    {
        // Call Result
        callResult = null;

        // Ping Request
        if (request.ToString() == "ping" && data.ToString() == "pong")
            return true;

        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    protected override bool HandleSubscriptionResponse(WebSocketConnection connection, WebSocketSubscription subscription, object request, JToken data, out CallResult<object> callResult)
    {
        callResult = null;
        if (data.Type != JTokenType.Object)
            return false;

        var bRequest = (BitMartWebSocketRequest)request;
        var forcedExit = false;

        var success = bRequest.HandleSubscriptionResponse(data, ref forcedExit);
        if (forcedExit) return false;

        if (success) callResult = new CallResult<object>(true);
        else
        {
            if (data["errorCode"] == null || data["errorMessage"] == null)
                callResult = new CallResult<object>(new ServerError(data["errorMessage"]!.ToString()));
            else
                callResult = new CallResult<object>(new ServerError(Convert.ToInt32((string)data["errorCode"]), (string)data["errorMessage"]));
        }

        return true;
    }

    /// <inheritdoc/>
    protected override bool MessageMatchesHandler(WebSocketConnection connection, JToken message, object request)
    {
        // Ping Request
        if (request.ToString() == "ping" && message.ToString() == "pong")
            return true;

        if (message.Type != JTokenType.Object)
            return false;

        return (request as BitMartWebSocketRequest)?.MessageMatchesHandler(message) ?? false;
    }

    /// <inheritdoc/>
    protected override bool MessageMatchesHandler(WebSocketConnection connection, JToken message, string identifier)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    protected override async Task<bool> UnsubscribeAsync(WebSocketConnection connection, WebSocketSubscription subscription)
    {
        var bRequest = ((BitMartWebSocketRequest)subscription.Request!);
        var request = new BitMartWebSocketRequest();

        // Spot WebSocket
        if (connection.Tag.Contains("ws-manager-compress.bitmart.com"))
        {
            request.Operation = "unsubscribe";
            request.Parameters = bRequest.Parameters;
        }

        // Futures WebSocket
        else if (connection.Tag.Contains("openapi-ws-v2.bitmart.com"))
        {
            request.Action = "access";
            request.Parameters = bRequest.Parameters;
        }

        // JSON
        var json = JsonConvert.SerializeObject(request);

        var result = false;
        await connection.SendAndWaitAsync(request, ClientOptions.ResponseTimeout, data =>
        {
            // Check Point
            if (data.Type != JTokenType.Object)
                return false;

            // Spot WebSocket
            if (data["event"] != null && data["topic"] != null)
            {
                var evt = (string)data["event"];
                var topic = (string)data["topic"];

                return evt == "unsubscribe" && bRequest.Parameters.Contains(topic);
            }

            // Futures WebSocket
            if (data["action"] != null && data["group"] != null && data["success"] != null)
            {
                var act = (string)data["action"];
                var group = (string)data["group"];
                var success = (bool)data["success"];

                return act == "subscribe" && bRequest.Parameters.Contains(group) && success;
            }

            // Return
            return false;
        });

        return result;
    }
    #endregion

    #region Internal Methods
    internal string GetAddress(BitMartApiSection section, bool signed)
    {
        var options = (BitMartWebSocketApiClientOptions)ClientOptions;
        var endpoint = options.SpotPublicAddress;

        if (section == BitMartApiSection.Spot)
        {
            if (signed) endpoint = options.SpotPrivateAddress;
            else endpoint = options.SpotPublicAddress;
        }
        else if (section == BitMartApiSection.Futures)
        {
            if (signed) endpoint = options.FuturesPrivateAddress;
            else endpoint = options.FuturesPublicAddress;
        }

        return endpoint;
    }
    internal string NextIdentifier()
        => NextId().ToString();
    internal Task<CallResult<WebSocketUpdateSubscription>> Subscribe<T>(string url, object request, string identifier, bool authenticated, Action<WebSocketDataEvent<T>> dataHandler, CancellationToken ct)
        => base.SubscribeAsync<T>(url, request, identifier, authenticated, dataHandler, ct);
    #endregion
}
