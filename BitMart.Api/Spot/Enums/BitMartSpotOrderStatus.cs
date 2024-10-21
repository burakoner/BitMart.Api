namespace BitMart.Api.Spot;

/// <summary>
/// Order status
/// </summary>
public enum BitMartSpotOrderStatus
{
    /// <summary>
    /// New
    /// </summary>
    [Map("new")]
    New = 1,

    /// <summary>
    /// Partially filled
    /// </summary>
    [Map("partially_filled")]
    PartiallyFilled = 2,

    /// <summary>
    /// Filled
    /// </summary>
    [Map("filled")]
    Filled = 3,

    /// <summary>
    /// Canceled
    /// </summary>
    [Map("canceled")]
    Canceled = 4,

    /// <summary>
    /// Partially canceled
    /// </summary>
    [Map("partially_canceled")]
    PartiallyCanceled = 5,

    /// <summary>
    /// Order failed
    /// </summary>
    [Map("failed")]
    Failed = 6
}
