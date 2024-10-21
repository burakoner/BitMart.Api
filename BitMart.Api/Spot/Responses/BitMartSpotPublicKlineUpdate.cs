namespace BitMart.Api.Spot;

/// <summary>
/// Kline update
/// </summary>
public record BitMartSpotPublicKlineUpdate
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Kline/candle data
    /// </summary>
    [JsonProperty("candle")]
    public BitMartSpotPublicKline Kline { get; set; }
}
