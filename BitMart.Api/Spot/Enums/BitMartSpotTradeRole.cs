namespace BitMart.Api.Spot;

/// <summary>
/// Trade role
/// </summary>
public enum BitMartSpotTradeRole
{
    /// <summary>
    /// Maker
    /// </summary>
    [Map("maker", "M", "Maker")]
    Maker,

    /// <summary>
    /// Taker
    /// </summary>
    [Map("taker", "T", "Taker")]
    Taker
}
