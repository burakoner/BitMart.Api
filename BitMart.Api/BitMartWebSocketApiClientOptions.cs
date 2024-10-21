namespace BitMart.Api;

/// <summary>
/// BitMart WebSocket Client Options
/// </summary>
public class BitMartWebSocketApiClientOptions : WebSocketApiClientOptions
{
    /// <summary>
    /// Spot WebSocket Public Address
    /// </summary>
    public string SpotPublicAddress { get; set; }

    /// <summary>
    /// Spot WebSocket Private Address
    /// </summary>
    public string SpotPrivateAddress { get; set; }
    
    /// <summary>
    /// Futures WebSocket Public Address
    /// </summary>
    public string FuturesPublicAddress { get; set; }

    /// <summary>
    /// Futures WebSocket Private Address
    /// </summary>
    public string FuturesPrivateAddress { get; set; }

    /// <summary>
    /// Heart Beat Interval
    /// </summary>
    public TimeSpan PingInterval { get; set; }

    /// <summary>
    /// Creates an instance of BitMart WebSocket Client Options
    /// </summary>
    public BitMartWebSocketApiClientOptions()
    {
        // Api Addresses
        this.SpotPublicAddress = BitMartAddress.MainNet.WebSocketSpotPublicAddress;
        this.SpotPrivateAddress = BitMartAddress.MainNet.WebSocketSpotPrivateAddress;
        this.FuturesPublicAddress = BitMartAddress.MainNet.WebSocketFuturesPublicAddress;
        this.FuturesPrivateAddress = BitMartAddress.MainNet.WebSocketFuturesPrivateAddress;

        // Heartbeat
        this.PingInterval = TimeSpan.FromSeconds(10);
    }
}
