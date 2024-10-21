namespace BitMart.Api.Futures;

/// <summary>
/// Futures order type
/// </summary>
public enum BitMartFuturesOrderType
{
    /// <summary>
    /// Limit order
    /// </summary>
    [Map("limit")]
    Limit = 1,

    /// <summary>
    /// Market order
    /// </summary>
    [Map("market")]
    Market = 2,

    /// <summary>
    /// Liquidation
    /// </summary>
    [Map("liquidate")]
    Liquidation = 3,

    /// <summary>
    /// Bankruptcy
    /// </summary>
    [Map("bankruptcy")]
    Bankruptcy = 4,

    /// <summary>
    /// Auto deleverage
    /// </summary>
    [Map("adl")]
    AutoDeleverage = 5,

    /// <summary>
    /// Trailing
    /// </summary>
    [Map("trailing", "trailing_order")]
    Trailing = 6,

    /// <summary>
    /// Plan order
    /// </summary>
    [Map("plan_order")]
    PlanOrder = 7,

    /// <summary>
    /// Take profit
    /// </summary>
    [Map("take_profit")]
    TakeProfit = 6,

    /// <summary>
    /// Stop loss
    /// </summary>
    [Map("stop_loss")]
    StopLoss = 6,
}
