namespace BitMart.Api.Futures;

/// <summary>
/// Futures account balance
/// </summary>
public record BitMartFuturesAccountBalance
{
    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Position margin
    /// </summary>
    [JsonProperty("position_deposit")]
    public decimal PositionMargin { get; set; }

    /// <summary>
    /// Frozen balance
    /// </summary>
    [JsonProperty("frozen_balance")]
    public decimal FrozenBalance { get; set; }

    /// <summary>
    /// Available balance
    /// </summary>
    [JsonProperty("available_balance")]
    public decimal AvailableBalance { get; set; }

    /// <summary>
    /// Equity
    /// </summary>
    [JsonProperty("equity")]
    public decimal Equity { get; set; }

    /// <summary>
    /// Unrealized profit and loss
    /// </summary>
    [JsonProperty("unrealized")]
    public decimal UnrealizedPnl { get; set; }
}
