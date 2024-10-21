namespace BitMart.Api.Spot;

internal record BitMartSpotSubAccountWrapper
{
    [JsonProperty("subAccountList")]
    public List<BitMartSpotSubAccount> Payload { get; set; } = [];
}

/// <summary>
/// Sub account info
/// </summary>
public record BitMartSpotSubAccount
{
    /// <summary>
    /// Account name
    /// </summary>
    [JsonProperty("accountName")]
    public string AccountName { get; set; }

    /// <summary>
    /// Account status
    /// </summary>
    [JsonProperty("status")]
    public BitMartSpotSubAccountStatus Status { get; set; }
}
