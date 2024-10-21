namespace BitMart.Api.Futures;

/// <summary>
/// Open interest
/// </summary>
public record BitMartFuturesPublicOpenInterest
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
    /// Open interest
    /// </summary>
    [JsonProperty("open_interest")]
    public decimal OpenInterest { get; set; }

    /// <summary>
    /// Open interest value
    /// </summary>
    [JsonProperty("open_interest_value")]
    public decimal OpenInterestValue { get; set; }
}
