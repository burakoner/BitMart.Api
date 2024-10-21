namespace BitMart.Api.Spot;

/// <summary>
/// BitMartSpotTransactionType
/// </summary>
public enum BitMartSpotTransactionType
{
    /// <summary>
    /// Deposit
    /// </summary>
    [Map("deposit")]
    Deposit = 1,

    /// <summary>
    /// Withdraw
    /// </summary>
    [Map("withdraw")]
    Withdraw = 2,
}