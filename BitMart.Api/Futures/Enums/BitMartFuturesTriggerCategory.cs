namespace BitMart.Api.Futures;

/// <summary>
/// Trigger order category
/// </summary>
public enum BitMartFuturesTriggerCategory
{
    /// <summary>
    /// Market
    /// </summary>
    [Map("market")]
    Market = 1,

    /// <summary>
    /// Limit
    /// </summary>
    [Map("limit")]
    Limit = 2,
}
