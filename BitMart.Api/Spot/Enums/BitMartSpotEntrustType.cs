namespace BitMart.Api.Spot;

/// <summary>
/// Entrust type
/// </summary>
public enum BitMartSpotEntrustType
{
    /// <summary>
    /// Normal (limit or market order)
    /// </summary>
    [Map("normal")]
    Normal,

    /// <summary>
    /// Limit maker
    /// </summary>
    [Map("limit_maker")]
    LimitMaker,

    /// <summary>
    /// Immediate or cancel
    /// </summary>
    [Map("ioc")]
    ImmediateOrCancel
}
