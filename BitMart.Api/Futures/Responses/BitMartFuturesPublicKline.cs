namespace BitMart.Api.Futures;

/// <summary>
/// Kline data
/// </summary>
public record BitMartFuturesPublicKline
{
    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Open price
    /// </summary>
    [JsonProperty("open_price")]
    public decimal OpenPrice { get; set; }

    /// <summary>
    /// Close price
    /// </summary>
    [JsonProperty("close_price")]
    public decimal ClosePrice { get; set; }

    /// <summary>
    /// High price
    /// </summary>
    [JsonProperty("high_price")]
    public decimal HighPrice { get; set; }

    /// <summary>
    /// Low price
    /// </summary>
    [JsonProperty("low_price")]
    public decimal LowPrice { get; set; }

    /// <summary>
    /// Volume
    /// </summary>
    [JsonProperty("volume")]
    public decimal Volume { get; set; }
}
