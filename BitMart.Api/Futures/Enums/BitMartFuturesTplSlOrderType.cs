namespace BitMart.Api.Futures;

/// <summary>
/// TakeProfit/StopLoss order type
/// </summary>
public enum BitMartFuturesTplSlOrderType
{
    /// <summary>
    /// Take profit order
    /// </summary>
    [Map("take_profit")]
    TakeProfit = 1,

    /// <summary>
    /// Stop loss order
    /// </summary>
    [Map("stop_loss")]
    StopLoss = 2,
}
