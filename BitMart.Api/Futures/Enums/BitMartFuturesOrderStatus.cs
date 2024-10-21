namespace BitMart.Api.Futures;

/// <summary>
/// Futures order status
/// </summary>
public enum BitMartFuturesOrderStatus
{
    /// <summary>
    /// Approval
    /// </summary>
    [Map("status_approval", "1")]
    Approval = 1,

    /// <summary>
    /// Check
    /// </summary>
    [Map("status_check", "2")]
    Check = 2,

    /// <summary>
    /// Finish
    /// </summary>
    [Map("status_finish", "4")]
    Finish = 4,
}
