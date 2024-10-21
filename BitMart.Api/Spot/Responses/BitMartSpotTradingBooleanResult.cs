namespace BitMart.Api.Spot;

internal record BitMartSpotTradingBooleanResult
{
    [JsonProperty("result")]
    public bool Payload { get; set; }
}
