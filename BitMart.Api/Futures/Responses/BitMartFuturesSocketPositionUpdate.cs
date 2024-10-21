namespace BitMart.Api.Futures;

/// <summary>
/// Position update
/// </summary>
public record BitMartFuturesSocketPositionUpdate
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Position size
    /// </summary>
    [JsonProperty("hold_volume")]
    public decimal PositionSize { get; set; }

    /// <summary>
    /// Position side
    /// </summary>
    [JsonProperty("position_type")]
    public BitMartFuturesPositionSide PositionSide { get; set; }

    /// <summary>
    /// Margin type
    /// </summary>
    [JsonProperty("open_type")]
    public BitMartFuturesMarginType MarginType { get; set; }

    /// <summary>
    /// Quantity frozen
    /// </summary>
    [JsonProperty("frozen_volume")]
    public decimal QuantityFrozen { get; set; }

    /// <summary>
    /// Quantity close
    /// </summary>
    [JsonProperty("close_volume")]
    public decimal QuantityClose { get; set; }

    /// <summary>
    /// Average position price
    /// </summary>
    [JsonProperty("hold_avg_price")]
    public decimal? AverageHoldPrice { get; set; }

    /// <summary>
    /// Average close price
    /// </summary>
    [JsonProperty("close_avg_price")]
    public decimal? AverageClosePrice { get; set; }

    /// <summary>
    /// Average open price
    /// </summary>
    [JsonProperty("open_avg_price")]
    public decimal? AverageOpenPrice { get; set; }

    /// <summary>
    /// Liquidation price
    /// </summary>
    [JsonProperty("liquidate_price")]
    public decimal? LiquidationPrice { get; set; }

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
}
