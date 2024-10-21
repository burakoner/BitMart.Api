namespace BitMart.Api.Futures;

/// <summary>
/// Order id
/// </summary>
public record BitMartFuturesTradingTpSlOrderResponse
{
    /// <summary>
    /// Order id
    /// </summary>
    [JsonProperty("order_id")]
    public long OrderId { get; set; }
    
    /// <summary>
    /// Client order id
    /// </summary>
    [JsonProperty("client_order_id")]
    public string ClientOrderId { get; set; }
}
