namespace BitMart.Api.Futures;

/// <summary>
/// BitMart Futures Account Rest API Client
/// </summary>
public class BitMartRestApiFuturesAccountClient
{
    // Endpoints
    private const string _contractPrivateAssetsDetail = "contract/private/assets-detail";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiFuturesAccountClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Applicable for querying user contract asset details
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public  Task<RestCallResult<List<BitMartFuturesAccountBalance>>> GetBalancesAsync(CancellationToken ct = default)
    {
        return _.RequestAsync<List<BitMartFuturesAccountBalance>>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateAssetsDetail), HttpMethod.Get, ct, true);
    }
}


