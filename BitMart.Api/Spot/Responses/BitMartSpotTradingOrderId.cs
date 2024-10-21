namespace BitMart.Api.Spot;

internal record BitMartSpotTradingOrderId
{
    /// <summary>
    /// Order id
    /// </summary>
    [JsonProperty("order_id")]
    public long OrderId { get; set; }
}
