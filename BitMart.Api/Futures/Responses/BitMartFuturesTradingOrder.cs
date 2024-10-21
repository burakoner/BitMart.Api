namespace BitMart.Api.Futures;

/// <summary>
/// Order info
/// </summary>
public record BitMartFuturesTradingOrder
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
    /// Order side
    /// </summary>
    [JsonProperty("side")]
    public BitMartFuturesOrderSide Side { get; set; }
    
    /// <summary>
    /// Order type
    /// </summary>
    [JsonProperty("type")]
    public BitMartFuturesOrderType Type { get; set; }
    
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
    /// Average price
    /// </summary>
    [JsonProperty("deal_avg_price")]
    public decimal? AveragePrice { get; set; }
    
    /// <summary>
    /// Quantity filled
    /// </summary>
    [JsonProperty("deal_size")]
    public decimal QuantityFilled { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("price")]
    public decimal? Price { get; set; }
    
    /// <summary>
    /// Order status
    /// </summary>
    [JsonProperty("state")]
    public BitMartFuturesOrderStatus Status { get; set; }
    
    /// <summary>
    /// Trailing order trigger price
    /// </summary>
    [JsonProperty("activation_price")]
    public decimal? TriggerPrice { get; set; }
    
    /// <summary>
    /// Trailing order callback rate
    /// </summary>
    [JsonProperty("callback_rate")]
    public decimal? CallbackRate { get; set; }
    
    /// <summary>
    /// Trailing order trigger price type
    /// </summary>
    [JsonProperty("activation_price_type")]
    public BitMartFuturesTriggerPriceType? TriggerPriceType { get; set; }
    
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
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// Update time
    /// </summary>
    [JsonProperty("update_time")]
    public DateTime? UpdateTime { get; set; }
    
    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Order id of the executed trigger order
    /// </summary>
    [JsonProperty("executive_order_id")]
    public string TriggerOrderId { get; set; }
}
