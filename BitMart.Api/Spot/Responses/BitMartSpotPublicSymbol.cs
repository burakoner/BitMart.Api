namespace BitMart.Api.Spot;

internal record BitMartSpotPublicSymbolWrapper
{
    [JsonProperty("symbols")]
    public List<BitMartSpotPublicSymbol> Payload { get; set; }
}

/// <summary>
/// BitMartSpotSymbol
/// </summary>
public record BitMartSpotPublicSymbol
{
    /// <summary>
    /// Trading pair name
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Trading pair id
    /// </summary>
    [JsonProperty("symbol_id")]
    public int SymbolId { get; set; }

    /// <summary>
    /// Base currency
    /// </summary>
    [JsonProperty("base_currency")]
    public string BaseCurrency { get; set; }

    /// <summary>
    /// Quote currency
    /// </summary>
    [JsonProperty("quote_currency")]
    public string QuoteCurrency { get; set; }

    /// <summary>
    /// The minimum order quantity is also the minimum order quantity increment
    /// </summary>
    [JsonProperty("quote_increment")]
    public decimal QuoteIncrement { get; set; }

    /// <summary>
    /// Minimum order quantity
    /// </summary>
    [JsonProperty("base_min_size")]
    public decimal BaseMinimumSize { get; set; }

    /// <summary>
    /// Minimum price accuracy (decimal places), used to query k-line and depth
    /// </summary>
    [JsonProperty("price_min_precision")]
    public int PricePrecisionMinimum { get; set; }

    /// <summary>
    /// Maximum price accuracy (decimal places), used to query k-line and depth
    /// </summary>
    [JsonProperty("price_max_precision")]
    public int PricePrecisionMaximum { get; set; }

    /// <summary>
    /// Expiration time of trading pair
    /// </summary>
    [JsonProperty("expiration")]
    public string Expiration { get; set; }

    /// <summary>
    /// Minimum order amount
    /// </summary>
    [JsonProperty("min_buy_amount")]
    public decimal MinimumBuyAmount { get; set; }

    /// <summary>
    /// Minimum sell amount
    /// </summary>
    [JsonProperty("min_sell_amount")]
    public decimal MinimumSellAmount { get; set; }

    /// <summary>
    /// Trade Status
    /// </summary>
    [JsonProperty("trade_status")]
    public BitMartSpotSymbolStatus Status { get; set; }
}
