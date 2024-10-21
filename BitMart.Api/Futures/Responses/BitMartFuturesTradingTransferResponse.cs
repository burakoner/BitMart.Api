namespace BitMart.Api.Futures;

/// <summary>
/// Transfer result
/// </summary>
public record BitMartFuturesTradingTransferResponse
{
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
}
