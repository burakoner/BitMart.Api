namespace BitMart.Api.Spot;

internal record BitMartSpotFundingCurrencyWrapper
{
    [JsonProperty("currencies")]
    public List<BitMartSpotFundingCurrency> Payload { get; set; }
}

/// <summary>
/// BitMartFundingCurrency
/// </summary>
public record BitMartSpotFundingCurrency
{
    /// <summary>
    /// Currency abbreviation, such as BTC
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Currency full name, such as Bitcoin
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Contract address
    /// </summary>
    [JsonProperty("contract_address")]
    public string ContractAddress { get; set; }

    /// <summary>
    /// network, e.g., 'ERC20'
    /// </summary>
    public string Network { get; set; }
    
    /// <summary>
    /// Availability to withdraw
    /// </summary>
    [JsonProperty("withdraw_enabled")]
    public bool WithdrawEnabled { get; set; }

    /// <summary>
    /// Availability to deposit
    /// </summary>
    [JsonProperty("deposit_enabled")]
    public bool DepositEnabled { get; set; }

    /// <summary>
    /// Minimum withdrawal amount
    /// </summary>
    [JsonProperty("withdraw_minsize")]
    public decimal WithdrawMinimumSize { get; set; }

    /// <summary>
    /// Minimum withdrawal fee
    /// </summary>
    [JsonProperty("withdraw_minfee")]
    public decimal WithdrawMinimumFee { get; set; }
}
