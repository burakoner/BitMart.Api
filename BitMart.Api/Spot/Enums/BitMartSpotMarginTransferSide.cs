namespace BitMart.Api.Spot;

/// <summary>
/// BitMartFundingMarginTransferSide
/// </summary>
public enum BitMartSpotMarginTransferSide
{
    /// <summary>
    /// Transfer in
    /// </summary>
    [Map("in")]
    TransferIn = 1,

    /// <summary>
    /// Transfer out
    /// </summary>
    [Map("out")]
    TransferOut = 2,
}