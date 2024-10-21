namespace BitMart.Api.Spot;

/// <summary>
/// User fee rate
/// </summary>
public record BitMartSpotFundingBasicFeeRate
{
    /// <summary>
    /// User fee rate type
    /// </summary>
    [JsonProperty("user_rate_type")]
    public BitMartSpotFeeRateType FeeRateType { get; set; }

    /// <summary>
    /// Level
    /// </summary>
    [JsonProperty("level")]
    public string Level { get; set; }

    /// <summary>
    /// Taker fee rate for Class-A pairs
    /// </summary>
    [JsonProperty("taker_fee_rate_A")]
    public decimal TakerFeeRateA { get; set; }

    /// <summary>
    /// Maker fee rate for Class-A pairs
    /// </summary>
    [JsonProperty("maker_fee_rate_A")]
    public decimal MakerFeeRateA { get; set; }

    /// <summary>
    /// Taker fee rate for Class-B pairs
    /// </summary>
    [JsonProperty("taker_fee_rate_B")]
    public decimal TakerFeeRateB { get; set; }

    /// <summary>
    /// Maker fee rate for Class-B pairs
    /// </summary>
    [JsonProperty("maker_fee_rate_B")]
    public decimal MakerFeeRateB { get; set; }

    /// <summary>
    /// Taker fee rate for Class-C pairs
    /// </summary>
    [JsonProperty("taker_fee_rate_C")]
    public decimal TakerFeeRateC { get; set; }

    /// <summary>
    /// Maker fee rate for Class-C pairs
    /// </summary>
    [JsonProperty("maker_fee_rate_C")]
    public decimal MakerFeeRateC { get; set; }

    /// <summary>
    /// Taker fee rate for Class-D pairs
    /// </summary>
    [JsonProperty("taker_fee_rate_D")]
    public decimal TakerFeeRateD { get; set; }

    /// <summary>
    /// Maker fee rate for Class-D pairs
    /// </summary>
    [JsonProperty("maker_fee_rate_D")]
    public decimal MakerFeeRateD { get; set; }
}
