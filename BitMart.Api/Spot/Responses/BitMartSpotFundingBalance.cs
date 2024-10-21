namespace BitMart.Api.Spot;

internal record BitMartSpotFundingBalanceWrapper
{
    /// <summary>
    /// Wallet
    /// </summary>
    [JsonProperty("wallet")]
    public List<BitMartSpotFundingBalance> Payload { get; set; } = [];
}

/// <summary>
/// BitMart Spot Balance
/// </summary>
public record BitMartSpotFundingBalance
{
    /// <summary>
    /// Token symbol, e.g., 'BTC'
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Token name, e.g., 'Bitcoin'
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Available Balance
    /// </summary>
    [JsonProperty("available")]
    public decimal Available { get; set; }

    /// <summary>
    /// Frozen Balance
    /// </summary>
    [JsonProperty("frozen")]
    public decimal Frozen { get; set; }
}
