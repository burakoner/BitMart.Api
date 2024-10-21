namespace BitMart.Api.Futures;

/// <summary>
/// User trade info
/// </summary>
public record BitMartFuturesTradingTrade
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
    /// Trade id
    /// </summary>
    [JsonProperty("trade_id")]
    public long TradeId { get; set; }

    /// <summary>
    /// Side
    /// </summary>
    [JsonProperty("side")]
    public BitMartFuturesOrderSide Side { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("vol")]
    public decimal Quantity { get; set; }
    
    /// <summary>
    /// Profit
    /// </summary>
    [JsonProperty("profit")]
    public bool Profit { get; set; }

    /// <summary>
    /// Role
    /// </summary>
    [JsonProperty("exec_type")]
    public BitMartSpotTradeRole? Role { get; set; }

    /// <summary>
    /// Realised profit and loss
    /// </summary>
    [JsonProperty("realised_profit")]
    public decimal RealisedPnl { get; set; }

    /// <summary>
    /// Fee paid
    /// </summary>
    [JsonProperty("paid_fees")]
    public decimal Fee { get; set; }

    /// <summary>
    /// Create time
    /// </summary>
    [JsonProperty("create_time")]
    public DateTime CreateTime { get; set; }
}
