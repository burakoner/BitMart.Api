namespace BitMart.Api.Spot;

/// <summary>
/// Deposit/Withdrawal status
/// </summary>
public enum BitMartSpotTransactionStatus
{
    /// <summary>
    /// Created
    /// </summary>
    [Map("0")]
    Created = 0,

    /// <summary>
    /// Submitted
    /// </summary>
    [Map("1")]
    Submitted = 1,

    /// <summary>
    /// Processsing
    /// </summary>
    [Map("2")]
    Processing = 2,

    /// <summary>
    /// Completed
    /// </summary>
    [Map("3")]
    Completed = 3,

    /// <summary>
    /// Canceled
    /// </summary>
    [Map("4")]
    Canceled = 4,

    /// <summary>
    /// Failed
    /// </summary>
    [Map("5")]
    Failed = 5,
}
