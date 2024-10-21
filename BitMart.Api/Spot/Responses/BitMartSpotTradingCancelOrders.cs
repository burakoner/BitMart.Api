namespace BitMart.Api.Spot;

/// <summary>
/// Cancel orders result
/// </summary>
public record BitMartSpotTradingCancelOrders
{
    /// <summary>
    /// Success ids
    /// </summary>
    [JsonProperty("successIds")]
    public List<string> SuccessIds { get; set; } = [];

    /// <summary>
    /// Fail ids
    /// </summary>
    [JsonProperty("failIds")]
    public List<string> FailIds { get; set; } = [];

    /// <summary>
    /// Total count
    /// </summary>
    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }

    /// <summary>
    /// Success count
    /// </summary>
    [JsonProperty("successCount")]
    public int SuccessCount { get; set; }

    /// <summary>
    /// Failed count
    /// </summary>
    [JsonProperty("failedCount")]
    public int FailedCount { get; set; }
}
