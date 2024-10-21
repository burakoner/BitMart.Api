namespace BitMart.Api.Spot;

internal record BitMartSpotSystemTime
{
    [JsonProperty("server_time")]
    public DateTime Payload { get; set; }
}