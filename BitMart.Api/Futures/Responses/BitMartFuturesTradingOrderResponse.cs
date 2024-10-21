namespace BitMart.Api.Futures;

/// <summary>
/// Futures order response
/// </summary>
public record BitMartFuturesTradingOrderResponse
{
    /// <summary>
    /// Order id
    /// </summary>
    [JsonProperty("order_id")]
    public long OrderId { get; set; }

    /// <summary>
    /// Price. Not that this is a string because when executing a market trade the server will return `market price` as string value.
    /// </summary>
    [JsonProperty("price")]
    public string Price { get; set; }
}
