namespace BitMart.Api.Futures;

/// <summary>
/// Position info
/// </summary>
public record BitMartFuturesTradingPosition
{
    /// <summary>
    /// Leverage
    /// </summary>
    [JsonProperty("leverage")]
    public decimal Leverage { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    
    /// <summary>
    /// Current fee
    /// </summary>
    [JsonProperty("current_fee")]
    public decimal? CurrentFee { get; set; }
    
    /// <summary>
    /// Open time
    /// </summary>
    [JsonProperty("open_timestamp")]
    public DateTime? OpenTime { get; set; }

    /// <summary>
    /// Current value
    /// </summary>
    [JsonProperty("current_value")]
    public decimal? CurrentValue { get; set; }

    /// <summary>
    /// Mark price
    /// </summary>
    [JsonProperty("mark_price")]
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// Position value
    /// </summary>
    [JsonProperty("position_value")]
    public decimal? PositionValue { get; set; }
    
    /// <summary>
    /// Open average price
    /// </summary>
    [JsonProperty("open_avg_price")]
    public decimal? OpenAveragePrice { get; set; }
    
    /// <summary>
    /// Close average price
    /// </summary>
    [JsonProperty("close_avg_price")]
    public decimal? CloseAveragePrice { get; set; }
    
    /// <summary>
    /// Entry price
    /// </summary>
    [JsonProperty("entry_price")]
    public decimal? EntryPrice { get; set; }
    
    /// <summary>
    /// Close volume
    /// </summary>
    [JsonProperty("close_vol")]
    public decimal? CloseVolume { get; set; }
    
    /// <summary>
    /// Position cross
    /// </summary>
    [JsonProperty("position_cross")]
    public decimal? PositionCross { get; set; }
    
    /// <summary>
    /// Maintenance margin
    /// </summary>
    [JsonProperty("maintenance_margin")]
    public decimal? MaintenanceMargin { get; set; }
    
    /// <summary>
    /// Margin type of the position
    /// </summary>
    [JsonProperty("margin_type")]
    public BitMartFuturesMarginType? MarginType { get; set; }
    
    /// <summary>
    /// Current quantity
    /// </summary>
    [JsonProperty("current_amount")]
    public decimal? CurrentQuantity { get; set; }
    
    /// <summary>
    /// Unrealized profit and loss
    /// </summary>
    [JsonProperty("unrealized_value")]
    public decimal? UnrealizedPnl { get; set; }
    
    /// <summary>
    /// Realized profit and loss
    /// </summary>
    [JsonProperty("realized_value")]
    public decimal RealizedPnl { get; set; }
    
    /// <summary>
    /// Position side
    /// </summary>
    [JsonProperty("position_type")]
    public BitMartFuturesPositionSide? PositionSide { get; set; }
    
    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }
}
