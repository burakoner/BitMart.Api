namespace BitMart.Api.Spot;

/// <summary>
/// BitMartSpotQueryState
/// </summary>
public enum BitMartSpotQueryState
{
    /// <summary>
    /// CID
    /// </summary>
    [Map("open")]
    Open = 1,

    /// <summary>
    /// History
    /// </summary>
    [Map("history")]
    History = 2,
}