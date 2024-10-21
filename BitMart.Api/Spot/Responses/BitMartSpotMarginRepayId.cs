namespace BitMart.Api.Spot;

internal record BitMartSpotMarginRepayId
{
    /// <summary>
    /// Repay Id
    /// </summary>
    [JsonProperty("repay_id")]
    public long RepayId { get; set; }
}
