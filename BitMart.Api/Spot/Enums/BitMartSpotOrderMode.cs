namespace BitMart.Api.Spot;

/// <summary>
/// Spot Mode
/// </summary>
public enum BitMartSpotOrderMode
{
    /// <summary>
    /// Spot
    /// </summary>
    [Map("spot")]
    Spot = 1,

    /// <summary>
    /// Isolated margin
    /// </summary>
    [Map("iso_margin")]
    IsolatedMargin = 2,
}
