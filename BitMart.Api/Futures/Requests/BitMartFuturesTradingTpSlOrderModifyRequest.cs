namespace BitMart.Api.Futures;

/// <summary>
/// Take Profit - Stop Loss Order Request
/// </summary>
public record BitMartFuturesTradingTpSlOrderModifyRequest
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    
    /// <summary>
    /// Order ID(order_id or client_order_id must give one)
    /// </summary>
    [JsonProperty("order_id")]
    public string OrderId { get; set; }

    /// <summary>
    /// Client order ID(order_id or client_order_id must give one)
    /// </summary>
    [JsonProperty("client_order_id")]
    public string ClientOrderId { get; set; }
    
    /// <summary>
    /// Trigger price
    /// </summary>
    [JsonProperty("trigger_price")]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal TriggerPrice { get; set; }
    
    /// <summary>
    /// Order price
    /// </summary>
    [JsonProperty("executive_price", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? OrderPrice { get; set; }
    
    /// <summary>
    /// Price type
    /// </summary>
    [JsonProperty("price_type")]
    public BitMartFuturesTriggerPriceType PriceType { get; set; }
    
    /// <summary>
    /// Plan category
    /// </summary>
    [JsonProperty("plan_category", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesTriggerPlanCategory? PlanCategory { get; set; }
    
    /// <summary>
    /// Plan category
    /// </summary>
    [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesTriggerCategory? Category { get; set; }
}
