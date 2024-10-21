namespace BitMart.Api.Futures;

/// <summary>
/// Position side
/// </summary>
public enum BitMartFuturesPositionSide
{
    /// <summary>
    /// Long
    /// </summary>
    [Map("1", "Long")]
    Long = 1,

    /// <summary>
    /// Short
    /// </summary>
    [Map("2", "Short")]
    Short = 2
}
