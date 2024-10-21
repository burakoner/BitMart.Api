namespace BitMart.Api.Spot;

internal record BitMartSpotSystemStatusWrapper
{
    [JsonProperty("service")]
    public List<BitMartSpotSystemStatus> Payload { get; set; }
}

/// <summary>
/// BitMartSystemStatus
/// </summary>
public record BitMartSpotSystemStatus
{
    /// <summary>
    /// System maintenance instructions title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// System maintenance status
    /// </summary>
    public BitMartSpotServiceStatus Status { get; set; }

    /// <summary>
    /// Service type
    /// </summary>
    [JsonProperty("service_type")]
    public BitMartSpotServiceType ServiceType { get; set; }

    /// <summary>
    /// System maintenance start time, UTC-0, timestamp accuracy in milliseconds
    /// </summary>
    [JsonProperty("start_time")]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// System maintenance end time, UTC-0, timestamp accuracy in milliseconds
    /// </summary>
    [JsonProperty("end_time")]
    public DateTime EndTime { get; set; }
}
