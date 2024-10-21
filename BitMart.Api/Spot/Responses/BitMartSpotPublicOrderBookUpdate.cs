namespace BitMart.Api.Spot;

/// <summary>
/// Order book
/// </summary>
public record BitMartSpotPublicOrderBookUpdate
{
    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("ms_t")]
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
/// Incremental order book update
/// </summary>
public record BitMartSpotPublicOrderBookIncrementalUpdate : BitMartSpotPublicOrderBookUpdate
{
    /// <summary>
    /// Update type
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    /// Data version
    /// </summary>
    [JsonProperty("version")]
    public long Version { get; set; }
}
