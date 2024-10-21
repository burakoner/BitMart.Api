namespace BitMart.Api.Futures;

/// <summary>
/// Transfer type
/// </summary>
public enum BitMartFuturesTransferType
{
    /// <summary>
    /// Spot to contract
    /// </summary>
    [Map("spot_to_contract")]
    SpotToContract = 1,

    /// <summary>
    /// Contract to spot
    /// </summary>
    [Map("contract_to_spot")]
    ContractToSpot = 2,
}
