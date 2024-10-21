namespace BitMart.Api.Futures;

/// <summary>
/// Trigger order info
/// </summary>
public record BitMartFuturesTradingTriggerOrderRequest
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
    /// Trigger order type
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesTriggerOrderType? Type { get; set; }
    
    /// <summary>
    /// Side
    /// </summary>
    [JsonProperty("side")]
    public BitMartFuturesOrderSide Side { get; set; }
    
    /// <summary>
    /// Leverage
    /// </summary>
    [JsonProperty("leverage")]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal Leverage { get; set; }
    
    /// <summary>
    /// Open type
    /// </summary>
    [JsonProperty("open_type")]
    public BitMartFuturesMarginType MarginType { get; set; }
    
    /// <summary>
    /// Mode
    /// </summary>
    [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesOrderMode? Mode { get; set; }
    
    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }
    
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
    /// Price way
    /// </summary>
    [JsonProperty("price_way")]
    public BitMartFuturesPriceWay PriceWay { get; set; }
    
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
    /// Pre-set TakeProfit trigger price type
    /// </summary>
    [JsonProperty("preset_take_profit_price_type", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesTriggerPriceType? PresetTakeProfitPriceType { get; set; }

    /// <summary>
    /// Pre-set StopLoss trigger price type
    /// </summary>
    [JsonProperty("preset_stop_loss_price_type", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesTriggerPriceType? PresetStopLossPriceType { get; set; }

    /// <summary>
    /// Pre-set TakeProfit price
    /// </summary>
    [JsonProperty("preset_take_profit_price", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? PresetTakeProfitPrice { get; set; }

    /// <summary>
    /// Pre-set StopLoss price
    /// </summary>
    [JsonProperty("preset_stop_loss_price", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? PresetStopLossPrice { get; set; }
}
