namespace BitMart.Api.Spot;

/// <summary>
/// BitMartSpotWithdrawalAccountType
/// </summary>
public enum BitMartSpotWithdrawalAccount
{
    /// <summary>
    /// CID
    /// </summary>
    [Map("1")]
    CID = 1,

    /// <summary>
    /// Email
    /// </summary>
    [Map("2")]
    Email = 2,

    /// <summary>
    /// Phone
    /// </summary>
    [Map("3")]
    Phone = 3,
}