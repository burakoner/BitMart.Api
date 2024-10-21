namespace BitMart.Api.Futures;

internal record BitMartFuturesPublicContractWrapper
{
    /// <summary>
    /// Symbols
    /// </summary>
    [JsonProperty("symbols")]
    public List<BitMartFuturesPublicContract> Payload { get; set; } = [];
}

/// <summary>
/// Contract info
/// </summary>
public record BitMartFuturesPublicContract
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Product type
    /// </summary>
    [JsonProperty("product_type")]
    public BitMartFuturesContractType ProductType { get; set; }
    
    /// <summary>
    /// Base Currency
    /// </summary>
    [JsonProperty("base_currency")]
    public string BaseCurrency { get; set; }

    /// <summary>
    /// Quote Currency
    /// </summary>
    [JsonProperty("quote_currency")]
    public string QuoteCurrency { get; set; }
    
    /// <summary>
    /// Quantity precision
    /// </summary>
    [JsonProperty("vol_precision")]
    public decimal QuantityPrecision { get; set; }

    /// <summary>
    /// Price precision
    /// </summary>
    [JsonProperty("price_precision")]
    public decimal PricePrecision { get; set; }
    
    /// <summary>
    /// Max quantity
    /// </summary>
    [JsonProperty("max_volume")]
    public decimal MaximumQuantity { get; set; }

    /// <summary>
    /// Min quantity
    /// </summary>
    [JsonProperty("min_volume")]
    public decimal MinimumQuantity { get; set; }
    
    /// <summary>
    /// Contract quantity
    /// </summary>
    [JsonProperty("contract_size")]
    public decimal ContractQuantity { get; set; }
    
    /// <summary>
    /// Index price
    /// </summary>
    [JsonProperty("index_price")]
    public decimal? IndexPrice { get; set; }

    /// <summary>
    /// Index name
    /// </summary>
    [JsonProperty("index_name")]
    public string IndexName { get; set; }
    
    /// <summary>
    /// Min leverage
    /// </summary>
    [JsonProperty("min_leverage")]
    public decimal MinimumLeverage { get; set; }

    /// <summary>
    /// Max leverage
    /// </summary>
    [JsonProperty("max_leverage")]
    public decimal MaximumLeverage { get; set; }
    
    /// <summary>
    /// Turnover24h
    /// </summary>
    [JsonProperty("turnover_24h")]
    public decimal Turnover24h { get; set; }
    
    /// <summary>
    /// Volume24h
    /// </summary>
    [JsonProperty("volume_24h")]
    public decimal Volume24h { get; set; }
    
    /// <summary>
    /// Last price
    /// </summary>
    [JsonProperty("last_price")]
    public decimal? LastPrice { get; set; }

    /// <summary>
    /// Open time
    /// </summary>
    [JsonProperty("open_timestamp")]
    public DateTime OpenTime { get; set; }

    /// <summary>
    /// Expire time
    /// </summary>
    [JsonProperty("expire_timestamp")]
    public DateTime? ExpireTime { get; set; }

    /// <summary>
    /// Settle time
    /// </summary>
    [JsonProperty("settle_timestamp")]
    public DateTime? SettleTime { get; set; }

    /// <summary>
    /// Funding rate
    /// </summary>
    [JsonProperty("funding_rate")]
    public decimal FundingRate { get; set; }

    /// <summary>
    /// Expected funding rate
    /// </summary>
    [JsonProperty("expected_funding_rate")]
    public decimal? ExpectedFundingRate { get; set; }

    /// <summary>
    /// Open interest
    /// </summary>
    [JsonProperty("open_interest")]
    public decimal OpenInterest { get; set; }

    /// <summary>
    /// Open interest value
    /// </summary>
    [JsonProperty("open_interest_value")]
    public decimal OpenInterestValue { get; set; }

    /// <summary>
    /// High price last 24h
    /// </summary>
    [JsonProperty("high_24h")]
    public decimal? HighPrice { get; set; }

    /// <summary>
    /// Low price last 24h
    /// </summary>
    [JsonProperty("low_24h")]
    public decimal? LowPrice { get; set; }

    /// <summary>
    /// Change in the last 24h
    /// </summary>
    [JsonProperty("change_24h")]
    public decimal Change24h { get; set; }

    /// <summary>
    /// Funding interval in hours
    /// </summary>
    [JsonProperty("funding_interval_hours")]
    public int 	FundingInterval { get; set; }
}
