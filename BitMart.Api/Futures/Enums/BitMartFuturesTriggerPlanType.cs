namespace BitMart.Api.Futures;

/// <summary>
/// Trigger plan type
/// </summary>
public enum BitMartFuturesTriggerPlanType
{
    /// <summary>
    /// Plan
    /// </summary>
    [Map("plan")]
    Plan = 1,

    /// <summary>
    /// Profit loss
    /// </summary>
    [Map("profit_loss")]
    ProfitLoss = 2,
}
