namespace BitMart.Api.Spot;

/// <summary>
/// Order update
/// </summary>
public record BitMartSpotTradingOrderUpdate
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
    /// Price
    /// </summary>
    [JsonProperty("price")]
    public decimal? Price { get; set; }
    
    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal? Quantity { get; set; }
    
    /// <summary>
    /// Quote quantity
    /// </summary>
    [JsonProperty("notional")]
    public decimal? QuoteQuantity { get; set; }

    /// <summary>
    /// Order side
    /// </summary>
    [JsonProperty("side")]
    public BitMartSpotOrderSide Side { get; set; }
    
    /// <summary>
    /// Order type
    /// </summary>
    [JsonProperty("type")]
    public BitMartSpotOrderType Type { get; set; }
    
    /// <summary>
    /// Order Create Timestamp (in milliseconds)
    /// </summary>
    [JsonProperty("ms_t")]
    public DateTime CreateTimestamp { get; set; }
    
    /// <summary>
    /// Quantity filled
    /// </summary>
    [JsonProperty("filled_size")]
    public decimal? QuantityFilled { get; set; }
    
    /// <summary>
    /// Quote quantity filled
    /// </summary>
    [JsonProperty("filled_notional")]
    public decimal? QuoteQuantityFilled { get; set; }
    
    /// <summary>
    /// Price of the last trade
    /// </summary>
    [JsonProperty("last_fill_price")]
    public decimal LastTradePrice { get; set; }
    
    /// <summary>
    /// Quantity of the last trade
    /// </summary>
    [JsonProperty("last_fill_count")]
    public decimal LastTradeQuantity { get; set; }
    
    /// <summary>
    /// Timestamp of the last trade
    /// </summary>
    [JsonProperty("last_fill_time")]
    public DateTime LastTradeTime { get; set; }
    
    /// <summary>
    /// Role of the last trade
    /// </summary>
    [JsonProperty("exec_type")]
    public BitMartSpotTradeRole? LastTradeRole { get; set; }

    /// <summary>
    /// Id of the last trade
    /// </summary>
    [JsonProperty("detail_id")]
    public long? LastTradeId { get; set; }
    
    /// <summary>
    /// Client order id
    /// </summary>
    [JsonProperty("client_order_id")]
    public string ClientOrderId { get; set; }
    
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
    /// Spot order mode
    /// </summary>
    [JsonProperty("order_mode")]
    public BitMartSpotOrderMode Mode { get; set; }
    
    /// <summary>
    /// Entrust type
    /// </summary>
    [JsonProperty("entrust_type")]
    public BitMartSpotEntrustType EntrustType { get; set; }

    /// <summary>
    /// Order status
    /// </summary>
    [JsonProperty("order_state")]
    public BitMartSpotOrderStatus Status { get; set; }
}
