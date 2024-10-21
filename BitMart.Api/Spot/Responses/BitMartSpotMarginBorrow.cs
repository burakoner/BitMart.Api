namespace BitMart.Api.Spot;

internal record BitMartSpotMarginBorrowWrapper
{
    /// <summary>
    /// Records
    /// </summary>
    [JsonProperty("records")]
    public List<BitMartSpotMarginBorrow> Payload { get; set; } = [];
}

/// <summary>
/// Borrow details
/// </summary>
public record BitMartSpotMarginBorrow
{
    /// <summary>
    /// Borrow id
    /// </summary>
    [JsonProperty("borrow_id")]
    public long BorrowId { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Borrow quantity
    /// </summary>
    [JsonProperty("borrow_amount")]
    public decimal BorrowQuantity { get; set; }

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
    /// Interest quantity
    /// </summary>
    [JsonProperty("interest_amount")]
    public decimal InterestQuantity { get; set; }

    /// <summary>
    /// Create time
    /// </summary>
    [JsonProperty("create_time")]
    public DateTime CreateTime { get; set; }
}
