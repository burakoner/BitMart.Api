namespace BitMart.Api.Futures;

/// <summary>
/// Order info
/// </summary>
public class BitMartFuturesTradingOrderRequest
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
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesOrderType? Type { get; set; }
    
    /// <summary>
    /// Order side
    /// </summary>
    [JsonProperty("side")]
    public BitMartFuturesOrderSide Side { get; set; }
    
    /// <summary>
    /// Leverage
    /// </summary>
    [JsonProperty("leverage", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? Leverage { get; set; }
    
    /// <summary>
    /// Open type
    /// </summary>
    [JsonProperty("open_type", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesMarginType? MarginType { get; set; }
    
    /// <summary>
    /// Order mode
    /// </summary>
    [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesOrderMode? OrderMode { get; set; }
    
    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? Price { get; set; }
    
    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }
    
    /// <summary>
    /// Trailing order trigger price
    /// </summary>
    [JsonProperty("activation_price", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? TriggerPrice { get; set; }
    
    /// <summary>
    /// Trailing order callback rate
    /// </summary>
    [JsonProperty("callback_rate", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DecimalStringWriterConverter))]
    public decimal? CallbackRate { get; set; }
    
    /// <summary>
    /// Trailing order trigger price type
    /// </summary>
    [JsonProperty("activation_price_type", NullValueHandling = NullValueHandling.Ignore)]
    public BitMartFuturesTriggerPriceType? TriggerPriceType { get; set; }
    
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
