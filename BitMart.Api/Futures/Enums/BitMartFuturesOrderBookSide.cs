namespace BitMart.Api.Futures;

/// <summary>
/// Side of the book
/// </summary>
public enum BitMartFuturesOrderBookSide
{
    /// <summary>
    /// Bids
    /// </summary>
    [Map("1")]
    Bids,

    /// <summary>
    /// Asks
    /// </summary>
    [Map("2")]
    Asks
}
