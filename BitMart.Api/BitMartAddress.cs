namespace BitMart.Api;

/// <summary>
/// BitMart Address
/// </summary>
public class BitMartAddress
{
    /// <summary>
    /// Spot Rest API Address
    /// </summary>
    public string RestApiSpotAddress { get; set; }

    /// <summary>
    /// Futures Rest API Address
    /// </summary>
    public string RestApiFuturesAddress { get; set; }

    /// <summary>
    /// Spot WebSocket Public Address
    /// </summary>
    public string WebSocketSpotPublicAddress { get; set; }

    /// <summary>
    /// Spot WebSocket Private Address
    /// </summary>
    public string WebSocketSpotPrivateAddress { get; set; }
    
    /// <summary>
    /// Futures WebSocket Public Address
    /// </summary>
    public string WebSocketFuturesPublicAddress { get; set; }

    /// <summary>
    /// Futures WebSocket Private Address
    /// </summary>
    public string WebSocketFuturesPrivateAddress { get; set; }

    /// <summary>
    /// MainNet Environment
    /// </summary>
    public static BitMartAddress MainNet = new()
    {
        RestApiSpotAddress = "https://api-cloud.bitmart.com",
        RestApiFuturesAddress = "https://api-cloud-v2.bitmart.com",
        WebSocketSpotPublicAddress = "wss://ws-manager-compress.bitmart.com/api?protocol=1.1",
        WebSocketSpotPrivateAddress = "wss://ws-manager-compress.bitmart.com/user?protocol=1.1",
        WebSocketFuturesPublicAddress = "wss://openapi-ws-v2.bitmart.com/api?protocol=1.1",
        WebSocketFuturesPrivateAddress = "wss://openapi-ws-v2.bitmart.com/user?protocol=1.1",
    };
}
