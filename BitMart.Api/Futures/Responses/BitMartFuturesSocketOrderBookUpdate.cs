namespace BitMart.Api.Futures;

/// <summary>
/// Order book
/// </summary>
public record BitMartFuturesSocketOrderBookUpdate
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    
    /// <summary>
    /// Side of the book
    /// </summary>
    [JsonProperty("way")]
    public BitMartFuturesOrderBookSide Side { get; set; }

    /// <summary>
    /// Depths, can either be bids or asks, check Side to see which
    /// </summary>
    [JsonProperty("depths")]
    public List<BitMartFuturesSocketOrderBookEntry> Depths { get; set; } = [];
    
    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("ms_t")]
    public DateTime Timestamp { get; set; }
}

/// <summary>
/// Order book entry
/// </summary>
public record BitMartFuturesSocketOrderBookEntry
{
    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("price")]
    public decimal Price { get; set; }
    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("vol")]
    public decimal Quantity { get; set; }
}
