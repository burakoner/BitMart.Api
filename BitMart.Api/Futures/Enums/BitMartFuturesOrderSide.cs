namespace BitMart.Api.Futures;

/// <summary>
/// Futures order side
/// </summary>
public enum BitMartFuturesOrderSide
{
    /// <summary>
    /// Buy open long
    /// </summary>
    [Map("1")]
    BuyOpenLong = 1,

    /// <summary>
    /// Buy close short
    /// </summary>
    [Map("2")]
    BuyCloseShort = 2,

    /// <summary>
    /// Sell close long
    /// </summary>
    [Map("3")]
    SellCloseLong = 3,

    /// <summary>
    /// Sell oen short
    /// </summary>
    [Map("4")]
    SellOpenShort = 4,
}
