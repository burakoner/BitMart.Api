﻿namespace BitMart.Api.Spot;

/// <summary>
/// Ticker update
/// </summary>
public record BitMartSpotPublicTickerUpdate
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Last price
    /// </summary>
    [JsonProperty("last_price")]
    public decimal LastPrice { get; set; }
    
    /// <summary>
    /// High price in last 24h
    /// </summary>
    [JsonProperty("high_24h")]
    public decimal HighPrice { get; set; }

    /// <summary>
    /// Low price in last 24h
    /// </summary>
    [JsonProperty("low_24h")]
    public decimal LowPrice { get; set; }

    /// <summary>
    /// Open price 24h ago
    /// </summary>
    [JsonProperty("open_24h")]
    public decimal OpenPrice { get; set; }

    /// <summary>
    /// Volume over last 24h in base asset
    /// </summary>
    [JsonProperty("base_volume_24h")]
    public decimal Volume24h { get; set; }

    /// <summary>
    /// Volume over last 24h in quote asset
    /// </summary>
    [JsonProperty("quote_volume_24h")]
    public decimal QuoteVolume24h { get; set; }
    
    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("ms_t")]
    public DateTime? Timestamp { get; set; }

    /// <summary>
    /// Price change factor
    /// </summary>
    [JsonProperty("fluctuation")]
    public decimal Change { get; set; }

    /// <summary>
    /// Best bid price
    /// </summary>
    [JsonProperty("bid_px")]
    public decimal BestBidPrice { get; set; }

    /// <summary>
    /// Best bid quantity
    /// </summary>
    [JsonProperty("bid_sz")]
    public decimal BestBidQuantity { get; set; }

    /// <summary>
    /// Best ask price
    /// </summary>
    [JsonProperty("ask_px")]
    public decimal BestAskPrice { get; set; }

    /// <summary>
    /// Best ask quantity
    /// </summary>
    [JsonProperty("ask_sz")]
    public decimal BestAskQuantity { get; set; }
}
