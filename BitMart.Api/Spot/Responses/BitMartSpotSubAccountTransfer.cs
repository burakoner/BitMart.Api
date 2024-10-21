namespace BitMart.Api.Spot;

/// <summary>
/// Transfer history
/// </summary>
public record BitMartSpotSubAccountTransferHistory
{
    /// <summary>
    /// Total
    /// </summary>
    [JsonProperty("total")]
    public int Total { get; set; }

    /// <summary>
    /// History list
    /// </summary>
    [JsonProperty("historyList")]
    public List<BitMartSpotSubAccountTransfer> HistoryList { get; set; } = [];
}

/// <summary>
/// Transfer info
/// </summary>
public record BitMartSpotSubAccountTransfer
{
    /// <summary>
    /// From account
    /// </summary>
    [JsonProperty("fromAccount")]
    public string FromAccount { get; set; }

    /// <summary>
    /// From wallet type
    /// </summary>
    [JsonProperty("fromWalletType")]
    public string FromWalletType { get; set; }

    /// <summary>
    /// To account
    /// </summary>
    [JsonProperty("toAccount")]
    public string ToAccount { get; set; }

    /// <summary>
    /// To wallet type
    /// </summary>
    [JsonProperty("toWalletType")]
    public string ToWalletType { get; set; }

    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("amount")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Submission time
    /// </summary>
    [JsonProperty("submissionTime")]
    public DateTime Timestamp { get; set; }
}
