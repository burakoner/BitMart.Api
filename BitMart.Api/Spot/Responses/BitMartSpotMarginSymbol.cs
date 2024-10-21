namespace BitMart.Api.Spot;

internal record BitMartSpotMarginSymbolWrapper
{
    /// <summary>
    /// Symbols
    /// </summary>
    [JsonProperty("symbols")]
    public List<BitMartSpotMarginSymbol> Payload { get; set; } = [];
}

/// <summary>
/// BitMartMarginSymbol
/// </summary>
public record BitMartSpotMarginSymbol
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Max leverage
    /// </summary>
    [JsonProperty("max_leverage")]
    public int MaximumLeverage { get; set; }

    /// <summary>
    /// Symbol enabled
    /// </summary>
    [JsonProperty("symbol_enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Base
    /// </summary>
    [JsonProperty("base")]
    public BitMartMarginAsset BaseCurrency { get; set; }

    /// <summary>
    /// Quote
    /// </summary>
    [JsonProperty("quote")]
    public BitMartMarginAsset QuoteCurrency { get; set; }
}

/// <summary>
/// Asset info
/// </summary>
public record BitMartMarginAsset
{
    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Daily interest
    /// </summary>
    [JsonProperty("daily_interest")]
    public decimal DailyInterest { get; set; }

    /// <summary>
    /// Hourly interest
    /// </summary>
    [JsonProperty("hourly_interest")]
    public decimal HourlyInterest { get; set; }

    /// <summary>
    /// Max borrow quantity
    /// </summary>
    [JsonProperty("max_borrow_amount")]
    public decimal MaximumBorrowQuantity { get; set; }

    /// <summary>
    /// Min borrow quantity
    /// </summary>
    [JsonProperty("min_borrow_amount")]
    public decimal MinimumBorrowQuantity { get; set; }

    /// <summary>
    /// Borrowable quantity
    /// </summary>
    [JsonProperty("borrowable_amount")]
    public decimal BorrowableQuantity { get; set; }
}
