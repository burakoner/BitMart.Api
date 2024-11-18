namespace BitMart.Api;

/// <summary>
/// BitMart Rest API Client Options
/// </summary>
public class BitMartRestApiClientOptions : RestApiClientOptions
{
    /// <summary>
    /// API Credentials
    /// </summary>
    public new BitMartApiCredentials ApiCredentials { get; set; }

    /// <summary>
    /// Receive Window 
    /// </summary>
    public TimeSpan ReceiveWindow { get; set; }

    /// <summary>
    /// Auto Timestamp
    /// </summary>
    public bool AutoTimestamp { get; set; }

    /// <summary>
    /// Auto Timestamp Recalculation Interval
    /// </summary>
    public TimeSpan AutoTimestampInterval { get; set; }

    /// <summary>
    /// Sign Public Requests
    /// </summary>
    public bool SignPublicRequests { get; set; } = false;

    /// <summary>
    /// Spot Rest API Address
    /// </summary>
    public string SpotAddress { get; set; }

    /// <summary>
    /// Futures Rest API Address
    /// </summary>
    public string FuturesAddress { get; set; }

    /// <summary>
    /// Broker Id
    /// </summary>
    public string BrokerId { get; set; }

    /// <summary>
    /// Creates an instance of BitMart Rest API Client Options
    /// </summary>
    public BitMartRestApiClientOptions() : this(null)
    {
        BaseAddress = BitMartAddress.MainNet.RestApiSpotAddress;
        SpotAddress = BitMartAddress.MainNet.RestApiSpotAddress;
        FuturesAddress = BitMartAddress.MainNet.RestApiFuturesAddress;
    }

    /// <summary>
    /// Creates an instance of BitMart Rest API Client Options
    /// </summary>
    /// <param name="credentials"></param>
    public BitMartRestApiClientOptions(BitMartApiCredentials credentials)
    {
        // API Credentials
        ApiCredentials = credentials;

        // Api Addresses
        BaseAddress = BitMartAddress.MainNet.RestApiSpotAddress;

        // Receive Window
        ReceiveWindow = TimeSpan.FromSeconds(30);

        // Auto Timestamp
        AutoTimestamp = true;
        AutoTimestampInterval = TimeSpan.FromHours(1);

        // Http Options
        HttpOptions = new HttpOptions
        {
            UserAgent = RestApiConstants.USER_AGENT,
            AcceptMimeType = RestApiConstants.JSON_CONTENT_HEADER,
            RequestTimeout = TimeSpan.FromSeconds(30),
            EncodeQueryString = true,
            BodyFormat = RestBodyFormat.Json,
        };

        // Broker Id
        BrokerId =  "AlgoTrading0001";
    }
}