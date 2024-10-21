namespace BitMart.Api.Spot;

/// <summary>
/// Fee rate type
/// </summary>
public enum BitMartSpotFeeRateType
{
    /// <summary>
    /// Normal user
    /// </summary>
    [Map("0")]
    Normal = 0,

    /// <summary>
    /// VIP user
    /// </summary>
    [Map("1")]
    Vip = 1,

    /// <summary>
    /// Special VIP user
    /// </summary>
    [Map("2")]
    SpecialVip = 2
}
