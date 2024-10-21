namespace BitMart.Api.Futures;

/// <summary>
/// Order update event
/// </summary>
public record BitMartFuturesSocketOrderUpdate
{
    /// <summary>
    /// Update trigger
    /// </summary>
    [JsonProperty("action")]
    public BitMartFuturesOrderEvent Event { get; set; }

    /// <summary>
    /// Order info
    /// </summary>
    [JsonProperty("order")]
    public BitMartFuturesSocketOrderUpdateData Order { get; set; }
}

/// <summary>
/// Order update
/// </summary>
public record BitMartFuturesSocketOrderUpdateData
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
    public BitMartFuturesOrderType OrderType { get; set; }

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
    /// Order id of the executed trigger order
    /// </summary>
    [JsonProperty("plan_order_id")]
    public long? TriggerOrderId { get; set; }

    /// <summary>
    /// Last trade info
    /// </summary>
    [JsonProperty("last_trade")]
    public BitMartFuturesOrderTrade LastTrade { get; set; }

    /// <summary>
    /// Trigger price of TP/SL / plan order
    /// </summary>
    [JsonProperty("trigger_price")]
    public decimal? TriggerPrice { get; set; }

    /// <summary>
    /// Trigger price type of TP/SL / plan order
    /// </summary>
    [JsonProperty("trigger_price_type")]
    public BitMartFuturesTriggerPriceType? TriggerPriceType { get; set; }

    /// <summary>
    /// Execution price of TP/SL / plan order
    /// </summary>
    [JsonProperty("execution_price")]
    public decimal? ExecutionPrice { get; set; }

    /// <summary>
    /// Activation price
    /// </summary>
    [JsonProperty("activation_price")]
    public decimal? ActivationPrice { get; set; }

    /// <summary>
    /// Activation price type
    /// </summary>
    [JsonProperty("activation_price_type")]
    public BitMartFuturesTriggerPriceType? ActivationPriceType { get; set; }

    /// <summary>
    /// Call back rate of trailing stop order
    /// </summary>
    [JsonProperty("callback_rate")]
    public decimal? CallbackRate { get; set; }
}

/// <summary>
/// Order trade info
/// </summary>
public record BitMartFuturesOrderTrade
{
    /// <summary>
    /// Id of the last trade
    /// </summary>
    [JsonProperty("lastTradeID")]
    public long TradeId { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("fillQty")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("fillPrice")]
    public decimal Price { get; set; }

    /// <summary>
    /// Fee
    /// </summary>
    [JsonProperty("fee")]
    public decimal Fee { get; set; }

    /// <summary>
    /// Fee asset
    /// </summary>
    [JsonProperty("feeCcy")]
    public string FeeAsset { get; set; }
}
