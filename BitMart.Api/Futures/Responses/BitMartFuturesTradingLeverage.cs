namespace BitMart.Api.Futures;

/// <summary>
/// Leverage info
/// </summary>
public record BitMartFuturesTradingLeverage
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Leverage
    /// </summary>
    [JsonProperty("leverage")]
    public decimal Leverage { get; set; }

    /// <summary>
    /// Open type
    /// </summary>
    [JsonProperty("open_type")]
    public BitMartFuturesMarginType MarginType { get; set; }

    /// <summary>
    /// Max value
    /// </summary>
    [JsonProperty("max_value")]
    public decimal MaximumValue { get; set; }
}
