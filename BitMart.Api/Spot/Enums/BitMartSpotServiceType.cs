namespace BitMart.Api.Spot;

/// <summary>
/// BitMartSystemServiceType
/// </summary>
public enum BitMartSpotServiceType
{
    /// <summary>
    /// Spot API service
    /// </summary>
    [Map("spot")]
    Spot = 1,

    /// <summary>
    /// Contract API service
    /// </summary>
    [Map("contract")]
    Contract = 2,

    /// <summary>
    /// Account API service
    /// </summary>
    [Map("account")]
    Account = 3,
}