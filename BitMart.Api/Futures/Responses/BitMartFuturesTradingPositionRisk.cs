namespace BitMart.Api.Futures;

/// <summary>
/// Position risk
/// </summary>
public record BitMartFuturesTradingPositionRisk
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Position quantity
    /// </summary>
    [JsonProperty("position_amt")]
    public decimal PositionQuantity { get; set; }

    /// <summary>
    /// Mark price
    /// </summary>
    [JsonProperty("mark_price")]
    public decimal MarkPrice { get; set; }

    /// <summary>
    /// Unrealized profit and loss
    /// </summary>
    [JsonProperty("unrealized_profit")]
    public decimal UnrealizedPnl { get; set; }

    /// <summary>
    /// Liquidation price
    /// </summary>
    [JsonProperty("liquidation_price")]
    public decimal LiquidationPrice { get; set; }

    /// <summary>
    /// Leverage
    /// </summary>
    [JsonProperty("leverage")]
    public decimal Leverage { get; set; }

    /// <summary>
    /// Maximum notional value for the current risk level
    /// </summary>
    [JsonProperty("max_notional_value")]
    public decimal MaximumNotionalValue { get; set; }

    /// <summary>
    /// Margin type
    /// </summary>
    [JsonProperty("margin_type")]
    public BitMartFuturesMarginType? MarginType { get; set; }

    /// <summary>
    /// Margin for isolated position
    /// </summary>
    [JsonProperty("isolated_margin")]
    public decimal? IsolatedMargin { get; set; }

    /// <summary>
    /// Position side
    /// </summary>
    [JsonProperty("position_side")]
    public BitMartFuturesPositionSide? PositionSide { get; set; }

    /// <summary>
    /// Notional
    /// </summary>
    [JsonProperty("notional")]
    public decimal Notional { get; set; }

    /// <summary>
    /// Update time
    /// </summary>
    [JsonProperty("update_time")]
    public DateTime? UpdateTime { get; set; }
}
