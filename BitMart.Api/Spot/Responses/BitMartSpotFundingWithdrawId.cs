namespace BitMart.Api.Spot;

/// <summary>
/// Withdrawal id
/// </summary>
public record BitMartSpotFundingWithdrawId
{
    /// <summary>
    /// Withdraw id
    /// </summary>
    [JsonProperty("withdraw_id")]
    public long WithdrawId { get; set; }
}
