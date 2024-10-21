namespace BitMart.Api.Spot;

internal record BitMartSpotPublicCurrencyWrapper
{
    [JsonProperty("currencies")]
    public List<BitMartSpotPublicCurrency> Payload { get; set; }
}

/// <summary>
/// BitMartSpotCurrency
/// </summary>
public record BitMartSpotPublicCurrency
{
    /// <summary>
    /// Currency abbreviation, such as BTC
    /// </summary>
    [JsonProperty("id")]
    public string Currency { get; set; }

    /// <summary>
    /// Currency full name, such as Bitcoin
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Whether this currency can be withdrawn on the platform
    /// </summary>
    [JsonProperty("withdraw_enabled")]
    public bool WithdrawEnabled { get; set; }

    /// <summary>
    /// Whether this currency can be deposited on the platform
    /// </summary>
    [JsonProperty("deposit_enabled")]
    public bool DepositEnabled { get; set; }
}
