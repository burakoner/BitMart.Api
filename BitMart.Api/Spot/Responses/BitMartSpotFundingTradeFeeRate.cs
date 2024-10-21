namespace BitMart.Api.Spot;

/// <summary>
/// Symbol trading fee
/// </summary>
public record BitMartSpotFundingTradeFeeRate
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Buy taker fee rate
    /// </summary>
    [JsonProperty("buy_taker_fee_rate")]
    public decimal BuyTakerFeeRate { get; set; }

    /// <summary>
    /// Sell taker fee rate
    /// </summary>
    [JsonProperty("sell_taker_fee_rate")]
    public decimal SellTakerFeeRate { get; set; }

    /// <summary>
    /// Buy maker fee rate
    /// </summary>
    [JsonProperty("buy_maker_fee_rate")]
    public decimal BuyMakerFeeRate { get; set; }

    /// <summary>
    /// Sell maker fee rate
    /// </summary>
    [JsonProperty("sell_maker_fee_rate")]
    public decimal SellMakerFeeRate { get; set; }
}
