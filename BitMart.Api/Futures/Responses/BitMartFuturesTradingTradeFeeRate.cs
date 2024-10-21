namespace BitMart.Api.Futures;

/// <summary>
/// Symbol trading fee
/// </summary>
public record BitMartFuturesTradingTradeFeeRate
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// taker fee rate
    /// </summary>
    [JsonProperty("taker_fee_rate")]
    public decimal TakerFeeRate { get; set; }

    /// <summary>
    /// maker fee rate
    /// </summary>
    [JsonProperty("maker_fee_rate")]
    public decimal MakerFeeRate { get; set; }
}
