namespace BitMart.Api.Spot;

/// <summary>
/// Transfer id
/// </summary>
public record BitMartSpotFundingTransferId
{
    /// <summary>
    /// Transfer Id
    /// </summary>
    [JsonProperty("transfer_id")]
    public long TransferId { get; set; }
}
