namespace BitMart.Api.Futures;

/// <summary>
/// Take Profit - Stop Loss Order Request
/// </summary>
public record BitMartFuturesTradingTpSlOrderRequest
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    
    /// <summary>
    /// Client order id
    /// </summary>
    [JsonProperty("client_order_id")]
    public string ClientOrderId { get; set; }

    /// <summary>
    /// Order type
    /// - take_profit
    /// - stop_loss
    /// </summary>
    [JsonProperty("type")]
    public BitMartFuturesTplSlOrderType Type { get; set; }
    
    /// <summary>
    /// Order side
    /// - 2: buy_close_short
    /// - 3: sell_close_long
    /// </summary>
    [JsonProperty("side")]
    public BitMartFuturesOrderSide Side { get; set; }
    
    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? Quantity { get; set; }
    
    /// <summary>
    /// Trigger price
    /// </summary>
    [JsonProperty("trigger_price")]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal TriggerPrice { get; set; }
    
    /// <summary>
    /// Order price
    /// </summary>
    [JsonProperty("executive_price")]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal OrderPrice { get; set; }
    
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
