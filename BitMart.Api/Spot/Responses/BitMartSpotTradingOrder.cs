namespace BitMart.Api.Spot;

/// <summary>
/// Order info
/// </summary>
public record BitMartSpotTradingOrder
{
    /// <summary>
    /// Order id
    /// </summary>
    [JsonProperty("orderId")]
    public long OrderId { get; set; }

    /// <summary>
    /// Client order id
    /// </summary>
    [JsonProperty("clientOrderId")]
    public string ClientOrderId { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order side
    /// </summary>
    [JsonProperty("side")]
    public BitMartSpotOrderSide Side { get; set; }

    /// <summary>
    /// Spot order mode
    /// </summary>
    [JsonProperty("orderMode")]
    public BitMartSpotOrderMode Mode { get; set; }

    /// <summary>
    /// Order type
    /// </summary>
    [JsonProperty("type")]
    public BitMartSpotOrderType OrderType { get; set; }

    /// <summary>
    /// Order status
    /// </summary>
    [JsonProperty("state")]
    public BitMartSpotOrderStatus Status { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("price")]
    public decimal? Price { get; set; }

    /// <summary>
    /// Price average
    /// </summary>
    [JsonProperty("priceAvg")]
    public decimal? PriceAverage { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Quantity filled
    /// </summary>
    [JsonProperty("filledSize")]
    public decimal? QuantityFilled { get; set; }

    /// <summary>
    /// Quote quantity
    /// </summary>
    [JsonProperty("notional")]
    public decimal? QuoteQuantity { get; set; }

    /// <summary>
    /// Quote quantity filled
    /// </summary>
    [JsonProperty("filledNotional")]
    public decimal? QuoteQuantityFilled { get; set; }

    /// <summary>
    /// Create time
    /// </summary>
    [JsonProperty("createTime")]
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// Update time
    /// </summary>
    [JsonProperty("updateTime")]
    public DateTime? UpdateTime { get; set; }
}
