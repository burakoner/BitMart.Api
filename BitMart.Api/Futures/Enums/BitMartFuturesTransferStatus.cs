namespace BitMart.Api.Futures;

/// <summary>
/// Transfer status
/// </summary>
public enum BitMartFuturesTransferStatus
{
    /// <summary>
    /// Processing
    /// </summary>
    [Map("PROCESSING")]
    Processing = 1,

    /// <summary>
    /// Finished
    /// </summary>
    [Map("FINISHED")]
    Finished = 2,

    /// <summary>
    /// Failed
    /// </summary>
    [Map("FAILED")]
    Failed = 3,
}
