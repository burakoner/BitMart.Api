namespace BitMart.Api.Futures;

/// <summary>
/// Contract type
/// </summary>
public enum BitMartFuturesContractType
{
    /// <summary>
    /// Perpetual contract
    /// </summary>
    [Map("1")]
    Perpetual = 1,

    /// <summary>
    /// Futures contract
    /// </summary>
    [Map("2")]
    Futures = 2
}
