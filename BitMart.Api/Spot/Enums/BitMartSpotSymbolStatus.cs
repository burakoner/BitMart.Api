namespace BitMart.Api.Spot;

/// <summary>
/// BitMartSpotSymbolStatus
/// </summary>
public enum BitMartSpotSymbolStatus
{
    /// <summary>
    /// PreTrade
    /// </summary>
    [Map("pre-trade")]
    PreTrade = 1,

    /// <summary>
    /// Trading
    /// </summary>
    [Map("trading")]
    Trading = 2,
}