namespace BitMart.Api.Futures;

/// <summary>
/// Trigger order category
/// </summary>
public enum BitMartFuturesTriggerPlanCategory
{
    /// <summary>
    /// Take profit / Stop loss
    /// </summary>
    [Map("1")]
    TpSl = 1,

    /// <summary>
    /// Position Take profit / Stop loss
    /// </summary>
    [Map("2")]
    PositionTpSl = 2,
}
