namespace BitMart.Api.Spot;

/// <summary>
/// Withdrawal quota
/// </summary>
public record BitMartSpotFundingWithdrawalQuota
{
    /// <summary>
    /// Todays available withdraw of BTC
    /// </summary>
    [JsonProperty("today_available_withdraw_BTC")]
    public decimal AvailableWithdrawBtc { get; set; }

    /// <summary>
    /// Min withdraw
    /// </summary>
    [JsonProperty("min_withdraw")]
    public decimal MinimumWithdraw { get; set; }

    /// <summary>
    /// Withdraw precision
    /// </summary>
    [JsonProperty("withdraw_precision")]
    public decimal WithdrawPrecision { get; set; }

    /// <summary>
    /// Withdraw fee
    /// </summary>
    [JsonProperty("withdraw_fee")]
    public decimal WithdrawFee { get; set; }

    /// <summary>
    /// Withdraw precision step
    /// </summary>
    [JsonProperty("withdraw_Precision_GeTen")]
    public decimal? WithdrawPrecisionStep { get; set; }
}
