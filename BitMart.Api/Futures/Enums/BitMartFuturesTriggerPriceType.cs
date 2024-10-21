namespace BitMart.Api.Futures;

/// <summary>
/// Trigger price type
/// </summary>
public enum BitMartFuturesTriggerPriceType
{
    /// <summary>
    /// Last price
    /// </summary>
    [Map("1")]
    LastPrice = 1,

    /// <summary>
    /// Fair price
    /// </summary>
    [Map("2")]
    FairPrice = 2,
}
