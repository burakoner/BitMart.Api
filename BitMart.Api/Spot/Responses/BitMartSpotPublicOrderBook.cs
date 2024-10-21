namespace BitMart.Api.Spot;

/// <summary>
/// Order book
/// </summary>
public record BitMartSpotPublicOrderBook
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
    public List<BitMartSpotPublicOrderBookEntry> Asks { get; set; } = [];

    /// <summary>
    /// Bids
    /// </summary>
    [JsonProperty("bids")]
    public List<BitMartSpotPublicOrderBookEntry> Bids { get; set; } = [];
}

/// <summary>
/// Order book entry
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public record BitMartSpotPublicOrderBookEntry
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
}
