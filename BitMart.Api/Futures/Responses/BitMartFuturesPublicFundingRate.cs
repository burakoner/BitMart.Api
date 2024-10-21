namespace BitMart.Api.Futures;

/// <summary>
/// Funding Rate
/// </summary>
public record BitMartFuturesPublicFundingRate
{
    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Funding rate of the previous period
    /// </summary>
    [JsonProperty("rate_value")]
    public decimal RateValue { get; set; }

    /// <summary>
    /// Funding rate for the next period
    /// </summary>
    [JsonProperty("expected_rate")]
    public decimal ExpectedRate { get; set; }

    /// <summary>
    /// Next funding settlement time
    /// </summary>
    [JsonProperty("funding_time")]
    public DateTime? FundingTime { get; set; }

    /// <summary>
    /// Upper limit of funding rate for this trading pair
    /// </summary>
    [JsonProperty("funding_upper_limit")]
    public decimal FundingUpperLimit { get; set; }

    /// <summary>
    /// Lower limit of funding rate for this trading pair
    /// </summary>
    [JsonProperty("funding_lower_limit")]
    public decimal FundingLowerLimit { get; set; }
}
