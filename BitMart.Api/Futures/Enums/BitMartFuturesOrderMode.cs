namespace BitMart.Api.Futures;

/// <summary>
/// Order mode
/// </summary>
public enum BitMartFuturesOrderMode
{
    /// <summary>
    /// Good till canceled
    /// </summary>
    [Map("1")]
    GoodTilCancel = 1,

    /// <summary>
    /// Fill entirely or cancel
    /// </summary>
    [Map("2")]
    FillOrKill = 2,

    /// <summary>
    /// Fill at least partially or cancel
    /// </summary>
    [Map("3")]
    ImmediateOrCancel = 3,

    /// <summary>
    /// Maker only
    /// </summary>
    [Map("4")]
    MakerOnly = 4,
}
