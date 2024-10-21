namespace BitMart.Api.Futures;

/// <summary>
/// Order id
/// </summary>
public record BitMartFuturesTradingOrderId
{
    /// <summary>
    /// Order id
    /// </summary>
    [JsonProperty("order_id")]
    public long OrderId { get; set; }
}
