namespace BitMart.Api.Futures;

/// <summary>
/// BitMart Futures Public Rest API Client
/// </summary>
public class BitMartRestApiFuturesPublicClient
{
    // Endpoints
    private const string _contractPublicDetails = "contract/public/details";
    private const string _contractPublicDepth = "contract/public/depth";
    private const string _contractPublicOpenInterest = "contract/public/open-interest";
    private const string _contractPublicFundingRate = "contract/public/funding-rate";
    private const string _contractPublicKline = "contract/public/kline";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiFuturesPublicClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Applicable to query contract details
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartFuturesPublicContract>>> GetContractsAsync(CancellationToken ct = default)
    {
        var result = await _.RequestAsync<BitMartFuturesPublicContractWrapper>(_.BuildUri(BitMartApiSection.Futures, _contractPublicDetails), HttpMethod.Get, ct);
        if (!result) return result.AsError<List<BitMartFuturesPublicContract>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// CancellationToken
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BitMartFuturesPublicContract>> GetContractAsync(string symbol, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection {
            { "symbol", symbol }
        };

        var result = await _.RequestAsync<BitMartFuturesPublicContractWrapper>(_.BuildUri(BitMartApiSection.Futures, _contractPublicDetails), HttpMethod.Get, ct, queryParameters: parameters);
        if (!result) return result.AsError<BitMartFuturesPublicContract>(result.Error);
        return result.As(result.Data.Payload.FirstOrDefault());
    }

    /// <summary>
    /// Get full depth of trading pairs.
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesPublicOrderBook>> GetOrderBookAsync(string symbol, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection { { "symbol", symbol } };

        return _.RequestAsync<BitMartFuturesPublicOrderBook>(_.BuildUri(BitMartApiSection.Futures, _contractPublicDepth), HttpMethod.Get, ct, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for querying the open interest and open interest value data of the specified contract
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesPublicOpenInterest>> GetOpenInterestAsync(string symbol, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection { { "symbol", symbol } };

        return _.RequestAsync<BitMartFuturesPublicOpenInterest>(_.BuildUri(BitMartApiSection.Futures, _contractPublicOpenInterest), HttpMethod.Get, ct, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for checking the current funding rate of a specified contract
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesPublicFundingRate>> GetFundingRateAsync(string symbol, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection { { "symbol", symbol } };

        return _.RequestAsync<BitMartFuturesPublicFundingRate>(_.BuildUri(BitMartApiSection.Futures, _contractPublicFundingRate), HttpMethod.Get, ct, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for querying K-line data
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="interval"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartFuturesPublicKline>>> GetKlinesAsync(
        string symbol,
        BitMartFuturesKlineInterval interval,
        long startTime,
        long endTime,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
            { "start_time", startTime },
            { "end_time", endTime }
        };
        parameters.AddEnum("step", interval);

        return _.RequestAsync<List<BitMartFuturesPublicKline>>(_.BuildUri(BitMartApiSection.Futures, _contractPublicKline), HttpMethod.Get, ct, false, queryParameters: parameters);
    }
}
