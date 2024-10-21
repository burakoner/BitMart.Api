namespace BitMart.Api.Futures;

/// <summary>
/// Order book
/// </summary>
public record BitMartFuturesPublicOrderBook
{
    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("ts")]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Asks
    /// </summary>
    [JsonProperty("asks")]
    public List<BitMartFuturesPublicOrderBookEntry> Asks { get; set; } = [];

    /// <summary>
    /// Bids
    /// </summary>
    [JsonProperty("bids")]
    public List<BitMartFuturesPublicOrderBookEntry> Bids { get; set; } = [];
}

/// <summary>
/// Order book entry
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public record BitMartFuturesPublicOrderBookEntry
{
    /// <summary>
    /// Price
    /// </summary>
    [ArrayProperty(0)]
    public decimal Price { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [ArrayProperty(1)]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [ArrayProperty(3)]
    public decimal AccumulativeQuantity { get; set; }
}
