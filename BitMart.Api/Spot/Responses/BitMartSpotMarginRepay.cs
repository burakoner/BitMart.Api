namespace BitMart.Api.Spot;

internal record BitMartSpotMarginRepayWrapper
{
    /// <summary>
    /// Records
    /// </summary>
    [JsonProperty("records")]
    public List<BitMartSpotMarginRepay> Payload { get; set; } = [];
}

/// <summary>
/// BitMartMarginRepay
/// </summary>
public record BitMartSpotMarginRepay
{
    /// <summary>
    /// Repay id
    /// </summary>
    [JsonProperty("repay_id")]
    public long RepayId { get; set; }

    /// <summary>
    /// Repay time
    /// </summary>
    [JsonProperty("repay_time")]
    public DateTime RepayTime { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Repaid quantity
    /// </summary>
    [JsonProperty("repaid_amount")]
    public decimal RepaidQuantity { get; set; }

    /// <summary>
    /// Repaid principal
    /// </summary>
    [JsonProperty("repaid_principal")]
    public decimal RepaidPrincipal { get; set; }

    /// <summary>
    /// Repaid interest
    /// </summary>
    [JsonProperty("repaid_interest")]
    public decimal RepaidInterest { get; set; }
}