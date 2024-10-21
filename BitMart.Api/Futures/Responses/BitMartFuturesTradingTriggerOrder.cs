namespace BitMart.Api.Futures;

/// <summary>
/// Trigger order info
/// </summary>
public record BitMartFuturesTradingTriggerOrder
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order id
    /// </summary>
    [JsonProperty("order_id")]
    public long OrderId { get; set; }

    /// <summary>
    /// Client order id
    /// </summary>
    [JsonProperty("client_order_id")]
    public string ClientOrderId { get; set; }
    
    /// <summary>
    /// Side
    /// </summary>
    [JsonProperty("side")]
    public BitMartFuturesOrderSide Side { get; set; }
    
    /// <summary>
    /// Trigger order type
    /// </summary>
    [JsonProperty("type")]
    public BitMartFuturesTriggerOrderType Type { get; set; }
    
    /// <summary>
    /// Plan category
    /// </summary>
    [JsonProperty("plan_category")]
    public BitMartFuturesTriggerPlanCategory PlanCategory { get; set; }
    
    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }
    
    /// <summary>
    /// Leverage
    /// </summary>
    [JsonProperty("leverage")]
    public decimal Leverage { get; set; }
    
    /// <summary>
    /// Open type
    /// </summary>
    [JsonProperty("open_type")]
    public BitMartFuturesMarginType MarginType { get; set; }
    
    /// <summary>
    /// Order price
    /// </summary>
    [JsonProperty("executive_price")]
    public decimal? OrderPrice { get; set; }

    /// <summary>
    /// Trigger price
    /// </summary>
    [JsonProperty("trigger_price")]
    public decimal TriggerPrice { get; set; }

    /// <summary>
    /// Order status
    /// </summary>
    [JsonProperty("state")]
    public BitMartFuturesOrderStatus Status { get; set; }
    
    /// <summary>
    /// Pre-set TakeProfit trigger price type
    /// </summary>
    [JsonProperty("preset_take_profit_price_type")]
    public BitMartFuturesTriggerPriceType? PresetTakeProfitPriceType { get; set; }

    /// <summary>
    /// Pre-set StopLoss trigger price type
    /// </summary>
    [JsonProperty("preset_stop_loss_price_type")]
    public BitMartFuturesTriggerPriceType? PresetStopLossPriceType { get; set; }

    /// <summary>
    /// Pre-set TakeProfit price
    /// </summary>
    [JsonProperty("preset_take_profit_price")]
    public decimal? PresetTakeProfitPrice { get; set; }

    /// <summary>
    /// Pre-set StopLoss price
    /// </summary>
    [JsonProperty("preset_stop_loss_price")]
    public decimal? PresetStopLossPrice { get; set; }
    
    /// <summary>
    /// Create time
    /// </summary>
    [JsonProperty("create_time")]
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// Update time
    /// </summary>
    [JsonProperty("update_time")]
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// Mode
    /// </summary>
    [JsonProperty("mode")]
    public BitMartFuturesOrderMode Mode { get; set; }

    /// <summary>
    /// Price way
    /// </summary>
    [JsonProperty("price_way")]
    public BitMartFuturesPriceWay? PriceWay { get; set; }

    /// <summary>
    /// Price type
    /// </summary>
    [JsonProperty("price_type")]
    public BitMartFuturesTriggerPriceType? PriceType { get; set; }
}
