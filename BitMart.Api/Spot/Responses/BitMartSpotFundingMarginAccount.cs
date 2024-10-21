namespace BitMart.Api.Spot;

internal record BitMartSpotFundingMarginAccountWrapper
{
    /// <summary>
    /// Symbols
    /// </summary>
    [JsonProperty("symbols")]
    public List<BitMartSpotFundingMarginAccount> Payload { get; set; } = [];
}

/// <summary>
/// Account info
/// </summary>
public record BitMartSpotFundingMarginAccount
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Risk rate
    /// </summary>
    [JsonProperty("risk_rate")]
    public decimal? RiskRate { get; set; }

    /// <summary>
    /// Risk level
    /// </summary>
    [JsonProperty("risk_level")]
    public decimal? RiskLevel { get; set; }

    /// <summary>
    /// Buy enabled
    /// </summary>
    [JsonProperty("buy_enabled")]
    public bool BuyEnabled { get; set; }

    /// <summary>
    /// Sell enabled
    /// </summary>
    [JsonProperty("sell_enabled")]
    public bool SellEnabled { get; set; }

    /// <summary>
    /// Liquidate price
    /// </summary>
    [JsonProperty("liquidate_price")]
    public decimal? LiquidatePrice { get; set; }

    /// <summary>
    /// Liquidate rate
    /// </summary>
    [JsonProperty("liquidate_rate")]
    public decimal? LiquidateRate { get; set; }

    /// <summary>
    /// Base
    /// </summary>
    [JsonProperty("base")]
    public BitMartSpotFundingMarginAccountAsset Base { get; set; }

    /// <summary>
    /// Quote
    /// </summary>
    [JsonProperty("quote")]
    public BitMartSpotFundingMarginAccountAsset Quote { get; set; }
}

/// <summary>
/// Account asset info
/// </summary>
public record BitMartSpotFundingMarginAccountAsset
{
    /// <summary>
    /// Currency
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Borrow enabled
    /// </summary>
    [JsonProperty("borrow_enabled")]
    public bool BorrowEnabled { get; set; }

    /// <summary>
    /// Borrowed
    /// </summary>
    [JsonProperty("borrowed")]
    public decimal Borrowed { get; set; }

    /// <summary>
    /// Borrow unpaid
    /// </summary>
    [JsonProperty("borrow_unpaid")]
    public decimal BorrowUnpaid { get; set; }

    /// <summary>
    /// Interest unpaid
    /// </summary>
    [JsonProperty("interest_unpaid")]
    public decimal InterestUnpaid { get; set; }

    /// <summary>
    /// Available
    /// </summary>
    [JsonProperty("available")]
    public decimal Available { get; set; }

    /// <summary>
    /// Frozen
    /// </summary>
    [JsonProperty("frozen")]
    public decimal Frozen { get; set; }

    /// <summary>
    /// Net asset
    /// </summary>
    [JsonProperty("net_asset")]
    public decimal NetAsset { get; set; }

    /// <summary>
    /// Net asset BTC
    /// </summary>
    [JsonProperty("net_assetBTC")]
    public decimal NetAssetBTC { get; set; }

    /// <summary>
    /// Total asset
    /// </summary>
    [JsonProperty("total_asset")]
    public decimal TotalAsset { get; set; }
}
