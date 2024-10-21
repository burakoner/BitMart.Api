namespace BitMart.Api.Spot;

/// <summary>
/// Order side
/// </summary>
public enum BitMartSpotOrderSide
{
    /// <summary>
    /// Buy
    /// </summary>
    [Map("buy")]
    Buy = 1,

    /// <summary>
    /// Sell
    /// </summary>
    [Map("sell")]
    Sell = 2,
}
