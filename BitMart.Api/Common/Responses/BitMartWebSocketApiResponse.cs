namespace BitMart.Api.Common;

internal class BitMartWebSocketApiResponse<T>
{
    [JsonProperty("group")]
    public string Group { get;set; }

    [JsonProperty("table")]
    public string Table { get;set; }

    [JsonProperty("data")]
    public T Payload { get; set; }
}