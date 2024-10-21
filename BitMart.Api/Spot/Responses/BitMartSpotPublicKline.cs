namespace BitMart.Api.Spot;

/// <summary>
/// BitMart Spot Kline
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public record BitMartSpotPublicKline
{
    /// <summary>
    /// Open time
    /// </summary>
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }

    /// <summary>
    /// Open price
    /// </summary>
    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }

    /// <summary>
    /// High price
    /// </summary>
    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }

    /// <summary>
    /// Low price
    /// </summary>
    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }

    /// <summary>
    /// close price
    /// </summary>
    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }

    /// <summary>
    /// Volume in base asset
    /// </summary>
    [ArrayProperty(5)]
    public decimal Volume { get; set; }

    /// <summary>
    /// Volume in quote asset
    /// </summary>
    [ArrayProperty(6)]
    public decimal? QuoteVolume { get; set; }
}
