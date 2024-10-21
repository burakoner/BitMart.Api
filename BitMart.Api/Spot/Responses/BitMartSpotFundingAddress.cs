namespace BitMart.Api.Spot;

/// <summary>
/// BitMartSpotFundingAddress
/// </summary>
public record BitMartSpotFundingAddress
{
    /// <summary>
    /// Token symbol, e.g., 'BTC'
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Token chain
    /// </summary>
    public string Chain { get; set; }

    /// <summary>
    /// Deposit address
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Available Balance
    /// </summary>
    [JsonProperty("address_memo")]
    public string AddressMemo { get; set; }
}
