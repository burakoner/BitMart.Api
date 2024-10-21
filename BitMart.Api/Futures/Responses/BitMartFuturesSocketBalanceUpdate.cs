namespace BitMart.Api.Futures;

/// <summary>
/// Blanace update
/// </summary>
public record BitMartFuturesSocketBalanceUpdate
{
    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Available balance
    /// </summary>
    [JsonProperty("available_balance")]
    public decimal Available { get; set; }

    /// <summary>
    /// Frozen balance
    /// </summary>
    [JsonProperty("frozen_balance")]
    public decimal Frozen { get; set; }

    /// <summary>
    /// Position Margin
    /// </summary>
    [JsonProperty("position_deposit")]
    public decimal PositionMargin { get; set; }
}
