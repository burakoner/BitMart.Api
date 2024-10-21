namespace BitMart.Api.Spot;

/// <summary>
/// Trade update
/// </summary>
public record BitMartSpotPublicTradeUpdate
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("ms_t")]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Side
    /// </summary>
    [JsonProperty("side")]
    public BitMartSpotOrderSide TakerSide { get; set; }
}
