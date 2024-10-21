namespace BitMart.Api.Spot;

internal record BitMartSpotTradingOrderIds
{
    /// <summary>
    /// Order IDs
    /// </summary>
    [JsonProperty("orderIds")]
    public List<long> Payload { get; set; } = [];
}
