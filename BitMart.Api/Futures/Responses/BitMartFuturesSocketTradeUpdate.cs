namespace BitMart.Api.Futures;

/// <summary>
/// Trade update
/// </summary>
public record BitMartFuturesSocketTradeUpdate
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("deal_price")]
    public decimal Price { get; set; }
    
    /// <summary>
    /// Trade id
    /// </summary>
    [JsonProperty("trade_id")]
    public long TradeId { get; set; }
    
    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("deal_vol")]
    public decimal Quantity { get; set; }

    // way
    // type

    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime Timestamp { get; set; }
}
