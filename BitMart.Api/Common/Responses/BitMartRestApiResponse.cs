namespace BitMart.Api.Common;

internal class BitMartRestApiResponse<T>
{
    public int Code { get;set; }
    public string Trace { get;set; }
    public string Message { get;set; }

    [JsonProperty("data")]
    public T Payload { get; set; }
}