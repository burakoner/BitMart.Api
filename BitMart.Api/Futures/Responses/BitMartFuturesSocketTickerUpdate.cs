namespace BitMart.Api.Futures;

/// <summary>
/// Ticker update
/// </summary>
public record BitMartFuturesSocketTickerUpdate
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    
    /// <summary>
    /// Last trade price
    /// </summary>
    [JsonProperty("last_price")]
    public decimal LastPrice { get; set; }

    /// <summary>
    /// Volume in past 24 hours
    /// </summary>
    [JsonProperty("volume_24")]
    public decimal Volume24h { get; set; }
    
    /// <summary>
    /// Price range
    /// </summary>
    [JsonProperty("range")]
    public decimal PriceRange { get; set; }

    /// <summary>
    /// Fair price
    /// </summary>
    [JsonProperty("fair_price")]
    public decimal FairPrice { get; set; }

    /// <summary>
    /// Best ask price
    /// </summary>
    [JsonProperty("ask_price")]
    public decimal BestAskPrice { get; set; }

    /// <summary>
    /// Best ask quantity
    /// </summary>
    [JsonProperty("ask_vol")]
    public decimal BestAskQuantity { get; set; }

    /// <summary>
    /// Best bid price
    /// </summary>
    [JsonProperty("bid_price")]
    public decimal BestBidPrice { get; set; }

    /// <summary>
    /// Best bid quantity
    /// </summary>
    [JsonProperty("bid_vol")]
    public decimal BestBidQuantity { get; set; }
}
