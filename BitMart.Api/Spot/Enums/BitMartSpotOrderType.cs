namespace BitMart.Api.Spot;

/// <summary>
/// Order type
/// </summary>
public enum BitMartSpotOrderType
{
    /// <summary>
    /// Limit order
    /// </summary>
    [Map("limit")]
    Limit = 1,

    /// <summary>
    /// Market order
    /// </summary>
    [Map("market")]
    Market = 2,

    /// <summary>
    /// Limit maker order
    /// </summary>
    [Map("limit_maker")]
    LimitMaker = 3,

    /// <summary>
    /// Immediate or cancel order
    /// </summary>
    [Map("ioc")]
    ImmediateOrCancel = 4,
}
