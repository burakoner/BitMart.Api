namespace BitMart.Api.Spot;

/// <summary>
/// Sub account status
/// </summary>
public enum BitMartSpotSubAccountStatus
{
    /// <summary>
    /// Disabled in background
    /// </summary>
    [Map("0")]
    Disabled = 0,

    /// <summary>
    /// Normal
    /// </summary>
    [Map("1")]
    Normal = 1,

    /// <summary>
    /// Frozen by main account
    /// </summary>
    [Map("2")]
    FrozenByMainAccount = 2
}
