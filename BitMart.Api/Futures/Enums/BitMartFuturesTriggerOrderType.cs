namespace BitMart.Api.Futures;

/// <summary>
/// Trigger order type
/// </summary>
public enum BitMartFuturesTriggerOrderType
{
    /// <summary>
    /// Plan order
    /// </summary>
    [Map("plan")]
    Plan = 1,

    /// <summary>
    /// Take profit order
    /// </summary>
    [Map("take_profit")]
    TakeProfit = 2,

    /// <summary>
    /// Stop loss order
    /// </summary>
    [Map("stop_loss")]
    StopLoss = 3,
}
