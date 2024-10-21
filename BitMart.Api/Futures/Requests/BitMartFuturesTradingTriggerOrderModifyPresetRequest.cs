namespace BitMart.Api.Futures;

/// <summary>
/// Trigger order info
/// </summary>
public record BitMartFuturesTradingTriggerOrderModifyPresetRequest
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
