namespace BitMart.Api.Spot;

/// <summary>
/// BitMartSystemServiceStatus
/// </summary>
public enum BitMartSpotServiceStatus
{
    /// <summary>
    /// Waiting
    /// </summary>
    [Map("0")]
    Waiting = 0,

    /// <summary>
    /// Working
    /// </summary>
    [Map("1")]
    Working = 1,

    /// <summary>
    /// Completed
    /// </summary>
    [Map("2")]
    Completed = 2,
}