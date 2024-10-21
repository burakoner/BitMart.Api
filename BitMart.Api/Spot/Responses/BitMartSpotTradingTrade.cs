namespace BitMart.Api.Spot;

/// <summary>
/// BitMartTradingTrade
/// </summary>
public record BitMartSpotTradingTrade
{
    /// <summary>
    /// Trade id
    /// </summary>
    [JsonProperty("tradeId")]
    public long TradeId { get; set; }
    
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
    /// Order mode
    /// </summary>
    [JsonProperty("orderMode")]
    public BitMartSpotOrderMode OrderMode { get; set; }

    /// <summary>
    /// Order type
    /// </summary>
    [JsonProperty("type")]
    public BitMartSpotOrderType OrderType { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// 	Transaction amount
    /// </summary>
    [JsonProperty("notional")]
    public decimal Notional { get; set; }

    /// <summary>
    /// Fee
    /// </summary>
    [JsonProperty("fee")]
    public decimal Fee { get; set; }

    /// <summary>
    /// Fee asset name
    /// </summary>
    [JsonProperty("feeCoinName")]
    public string FeeAsset { get; set; }

    /// <summary>
    /// Trade role
    /// </summary>
    [JsonProperty("tradeRole")]
    public BitMartSpotTradeRole TradeRole { get; set; }

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
