namespace BitMart.Api.Spot;

internal record BitMartSpotSubAccountBalanceWrapper
{
    [JsonProperty("wallet")]
    public List<BitMartSpotSubAccountBalance> Payload { get; set; } = [];
}

/// <summary>
/// Sub account balance
/// </summary>
public record BitMartSpotSubAccountBalance
{
    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Available
    /// </summary>
    [JsonProperty("available")]
    public decimal Available { get; set; }

    /// <summary>
    /// Frozen
    /// </summary>
    [JsonProperty("frozen")]
    public decimal Frozen { get; set; }
}
