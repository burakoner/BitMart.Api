namespace BitMart.Api.Futures;

internal record BitMartFuturesTradingTransferWrapper
{
    /// <summary>
    /// Records
    /// </summary>
    [JsonProperty("records")]
    public List<BitMartFuturesTradingTransfer> Payload { get; set; } = [];
}

/// <summary>
/// Futures transfer record
/// </summary>
public record BitMartFuturesTradingTransfer
{
    /// <summary>
    /// Transfer id
    /// </summary>
    [JsonProperty("transfer_id")]
    public long TransferId { get; set; }

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
    /// Type
    /// </summary>
    [JsonProperty("type")]
    public BitMartFuturesTransferType? Type { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    [JsonProperty("state")]
    public BitMartFuturesTransferStatus Status { get; set; }

    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }
}
