namespace BitMart.Api;

/// <summary>
/// BitMart Rest API Client
/// </summary>
public class BitMartRestApiClient : RestApiClient
{
    /// <summary>
    /// BitMart Spot Rest API Client
    /// </summary>
    public BitMartRestApiSpotClient Spot { get; }

    /// <summary>
    /// BitMart Futures Rest API Client
    /// </summary>
    public BitMartRestApiFuturesClient Futures { get; }

    // Internal
    internal ILogger Logger { get => _logger; }
    internal TimeSyncState TimeSyncState = new("BitMart Rest API");
    internal CultureInfo InvariantCultureInfo = CultureInfo.InvariantCulture;

    /// <summary>
    /// Create a new instance of the BitMart Rest API Client
    /// </summary>
    public BitMartRestApiClient() : this(null, new BitMartRestApiClientOptions())
    {
    }

    /// <summary>
    /// Create a new instance of the BitMart Rest API Client
    /// </summary>
    /// <param name="options"></param>
    public BitMartRestApiClient(BitMartRestApiClientOptions options) : this(null, options)
    {
    }

    /// <summary>
    /// Create a new instance of the BitMart Rest API Client
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="options"></param>
    public BitMartRestApiClient(ILogger logger, BitMartRestApiClientOptions options) : base(logger, options)
    {
        this.Spot = new BitMartRestApiSpotClient(this);
        this.Futures = new BitMartRestApiFuturesClient(this);
    }

    /// <summary>
    /// Set the API Credentials
    /// </summary>
    /// <param name="key"></param>
    /// <param name="secret"></param>
    /// <param name="memo"></param>
    public void SetApiCredentials(string key, string secret, string memo)
        => this.SetApiCredentials(new BitMartApiCredentials(key, secret, memo));

    #region Override Methods
    /// <inheritdoc />
    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
        => new BitMartAuthenticationProvider((BitMartApiCredentials)credentials);

    /// <inheritdoc />
    protected override Error ParseErrorResponse(JToken error)
    {
        if (!error.HasValues)
            return new ServerError(error.ToString());

        if (error["code"] == null && string.IsNullOrEmpty((string)error["message"]))
            return new ServerError(error.ToString());

        if (error["code"] == null && !string.IsNullOrEmpty((string)error["message"]))
            return new ServerError((string)error["message"]!);

        return new ServerError((int)error["code"], (string)error["message"]);
    }

    /// <inheritdoc />
    protected override Task<RestCallResult<DateTime>> GetServerTimestampAsync() => this.Spot.System.GetTimeAsync();

    /// <inheritdoc />
    protected override TimeSpan GetTimeOffset() => TimeSyncState.TimeOffset;

    /// <inheritdoc />
    protected override TimeSyncInfo GetTimeSyncInfo() => new(
        _logger,
        ((BitMartRestApiClientOptions)ClientOptions).AutoTimestamp,
        ((BitMartRestApiClientOptions)ClientOptions).AutoTimestampInterval,
        TimeSyncState);
    #endregion

    #region Internal Methods
    internal async Task<RestCallResult<T>> RequestAsync<T>(Uri uri, HttpMethod method, CancellationToken cancellationToken, bool signed = false, ParameterCollection queryParameters = null, ParameterCollection bodyParameters = null, Dictionary<string, string> headerParameters = null, ArraySerialization? arraySerialization = null, JsonSerializer deserializer = null, bool ignoreRatelimit = false, int requestWeight = 1)
    {
        // Get Original Cultures
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var currentUICulture = Thread.CurrentThread.CurrentUICulture;

        // Set Cultures
        Thread.CurrentThread.CurrentCulture = InvariantCultureInfo;
        Thread.CurrentThread.CurrentUICulture = InvariantCultureInfo;

        // Do Request
        var result = await SendRequestAsync<BitMartRestApiResponse<T>>(uri, method, cancellationToken, signed, queryParameters, bodyParameters, headerParameters, arraySerialization, deserializer, ignoreRatelimit, requestWeight).ConfigureAwait(false);

        // Set Orifinal Cultures
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Thread.CurrentThread.CurrentUICulture = currentUICulture;

        // Return
        if (!result.Success || result.Data == null) return new RestCallResult<T>(result.Request, result.Response, result.Raw, result.Error);
        if (result.Data.Code != 1000) return new RestCallResult<T>(result.Request, result.Response, result.Raw, new ServerError(result.Data.Code, result.Data.Message));
        return new RestCallResult<T>(result.Request, result.Response, result.Data.Payload, result.Raw, result.Error);
    }

    internal Uri BuildUri(BitMartApiSection section, params string[] parameters)
    {
        var options = (BitMartRestApiClientOptions)ClientOptions;
        var endpoint = options.BaseAddress;

        if (section == BitMartApiSection.Spot) endpoint = options.SpotAddress;
        else if (section == BitMartApiSection.Futures) endpoint = options.FuturesAddress;

        return new Uri($"{endpoint.TrimEnd('/')}/{string.Join("/", parameters).TrimStart('/')}");
    }
    #endregion

}
