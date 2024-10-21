namespace BitMart.Api.Spot;

/// <summary>
/// BitMartTradingOrderRequest
/// </summary>
public record BitMartTradingOrderRequest
{
    /// <summary>
    /// Side
    /// </summary>
    [JsonProperty("side")]
    public BitMartSpotOrderSide Side { get; set; }

    /// <summary>
    /// Order type
    /// </summary>
    [JsonProperty("type")]
    public BitMartSpotOrderType Type { get; set; }

    /// <summary>
    /// Client-defined OrderId(A combination of numbers and letters, less than 32 bits)
    /// </summary>
    [JsonProperty("clientOrderId", NullValueHandling = NullValueHandling.Ignore)]
    public string ClientOrderId { get; set; }

    /// <summary>
    /// Order size
    /// </summary>
    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? Price { get; set; }

    /// <summary>
    /// Required for placing orders by amount
    /// </summary>
    [JsonProperty("notional", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? QuoteQuantity { get; set; }
}
