namespace BitMart.Api.Spot;

/// <summary>
/// Trade info
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public record BitMartSpotPublicTrade
{
    /// <summary>
    /// Symbol
    /// </summary>
    [ArrayProperty(0)]
    public string Symbol { get; set; }

    /// <summary>
    /// Timestamp
    /// </summary>
    [ArrayProperty(1), JsonConverter(typeof(DateTimeConverter))]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [ArrayProperty(2)]
    public decimal Price { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [ArrayProperty(3)]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Side
    /// </summary>
    [ArrayProperty(4)]
    public BitMartSpotOrderSide Side { get; set; }
}
