namespace BitMart.Api.Spot;

/// <summary>
/// Balance update
/// </summary>
public record BitMartSpotFundingBalanceUpdate
{
    /// <summary>
    /// Event type
    /// </summary>
    [JsonProperty("event_type")]
    public BitMartSpotBalanceUpdateType EventType { get; set; }

    /// <summary>
    /// Event time
    /// </summary>
    [JsonProperty("event_time")]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Updated balances
    /// </summary>
    [JsonProperty("balance_details")]
    public List<BitMartSpotFundingBalanceUpdateDetails> Balances { get; set; } = [];
}

/// <summary>
/// Asset info
/// </summary>
public record BitMartSpotFundingBalanceUpdateDetails
{
    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("ccy")]
    public string Currency { get; set; }

    /// <summary>
    /// Available balance
    /// </summary>
    [JsonProperty("av_bal")]
    public decimal Available { get; set; }

    /// <summary>
    /// Frozen balance
    /// </summary>
    [JsonProperty("fz_bal")]
    public decimal Frozen { get; set; }
}
