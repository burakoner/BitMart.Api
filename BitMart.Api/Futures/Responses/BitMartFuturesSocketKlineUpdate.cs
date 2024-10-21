namespace BitMart.Api.Futures;

/// <summary>
/// Kline data
/// </summary>
public record BitMartFuturesSocketKlineUpdate
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Kline items
    /// </summary>
    [JsonProperty("items")]
    public List<BitMartFuturesSocketKline> Klines { get; set; } = [];
}

/// <summary>
/// Kline data
/// </summary>
public record BitMartFuturesSocketKline
{
    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("ts")]
    public DateTime? Timestamp { get; set; }

    /// <summary>
    /// Open price
    /// </summary>
    [JsonProperty("o")]
    public decimal OpenPrice { get; set; }

    /// <summary>
    /// Close price
    /// </summary>
    [JsonProperty("c")]
    public decimal ClosePrice { get; set; }

    /// <summary>
    /// High price
    /// </summary>
    [JsonProperty("h")]
    public decimal HighPrice { get; set; }

    /// <summary>
    /// Low price
    /// </summary>
    [JsonProperty("l")]
    public decimal LowPrice { get; set; }

    /// <summary>
    /// Volume
    /// </summary>
    [JsonProperty("v")]
    public decimal Volume { get; set; }
}
