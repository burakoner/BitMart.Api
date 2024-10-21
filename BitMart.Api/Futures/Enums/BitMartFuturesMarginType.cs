namespace BitMart.Api.Futures;

/// <summary>
/// Margin type
/// </summary>
public enum BitMartFuturesMarginType
{
    /// <summary>
    /// Cross margin
    /// </summary>
    [Map("cross", "Cross")]
    CrossMargin = 1,

    /// <summary>
    /// Isolated margin
    /// </summary>
    [Map("isolated", "Isolated")]
    IsolatedMargin = 2,
}
