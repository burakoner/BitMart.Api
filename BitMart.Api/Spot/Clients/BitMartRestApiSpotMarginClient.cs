namespace BitMart.Api.Spot;

/// <summary>
/// BitMart Margin Loan Rest API Client
/// </summary>
public class BitMartRestApiSpotMarginClient
{
    // Endpoints
    private const string _spotV1MarginIsolatedBorrow = "spot/v1/margin/isolated/borrow";
    private const string _spotV1MarginIsolatedRepay = "spot/v1/margin/isolated/repay";
    private const string _spotV1MarginIsolatedBorrowRecord = "spot/v1/margin/isolated/borrow_record";
    private const string _spotV1MarginIsolatedRepayRecord = "spot/v1/margin/isolated/repay_record";
    private const string _spotV1MarginIsolatedPairs = "spot/v1/margin/isolated/pairs";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiSpotMarginClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Applicable to isolated margin account borrowing operations
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="currency">Borrowing currency, selected according to the borrowing trading pair(like BTC or USDT)</param>
    /// <param name="amount">Amount of borrowing (precision: 8 decimal places)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<long>> BorrowAsync(
        string symbol,
        string currency,
        decimal amount,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
            { "currency", currency },
        };
        parameters.AddString("amount", amount);

        var result = await _.RequestAsync<BitMartSpotMarginBorrowId>(_.BuildUri(BitMartApiSection.Spot, _spotV1MarginIsolatedBorrow), HttpMethod.Post, ct, true, bodyParameters: parameters);
        if (!result) return result.AsError<long>(result.Error);
        return result.As(result.Data.BorrowId);
    }

    /// <summary>
    /// Applicable to isolated margin account repayment operations
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="currency">Repayment currency, selected according to the borrowing trading pair(like BTC or USDT)</param>
    /// <param name="amount">Amount of repayments (precision: 8 decimal places)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<long>> RepayAsync(
        string symbol,
        string currency,
        decimal amount,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
            { "currency", currency },
        };
        parameters.AddString("amount", amount);

        var result = await _.RequestAsync<BitMartSpotMarginRepayId>(_.BuildUri(BitMartApiSection.Spot, _spotV1MarginIsolatedRepay), HttpMethod.Post, ct, true, bodyParameters: parameters);
        if (!result) return result.AsError<long>(result.Error);
        return result.As(result.Data.RepayId);
    }

    /// <summary>
    /// Applicable to the inquiry of borrowing records of an isolated margin account
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="borrowId">Borrow order id</param>
    /// <param name="startTime">Query start time: Timestamp</param>
    /// <param name="endTime">Query end time: Timestamp</param>
    /// <param name="limit">Query record size, allowed range[1-100]. Default is 50</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotMarginBorrow>>> GetBorrowsAsync(
        string symbol,
        long? borrowId = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("borrow_id", borrowId);
        parameters.AddOptional("start_time", startTime);
        parameters.AddOptional("end_time", endTime);
        parameters.AddOptional("N", limit);

        var result = await _.RequestAsync<BitMartSpotMarginBorrowWrapper>(_.BuildUri(BitMartApiSection.Spot, _spotV1MarginIsolatedBorrowRecord), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<List<BitMartSpotMarginBorrow>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Applicable to the inquiry of repayment records of isolated margin account
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="repayId">Repayment ID</param>
    /// <param name="currency">Currency</param>
    /// <param name="startTime">Query start time: Timestamp</param>
    /// <param name="endTime">Query end time: Timestamp</param>
    /// <param name="limit">Query record size, allowed range[1-100]. Default is 50</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotMarginRepay>>> GetRepaysAsync(
        string symbol,
        long? repayId = null,
        string currency = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("repay_id", repayId);
        parameters.AddOptional("start_time", startTime);
        parameters.AddOptional("end_time", endTime);
        parameters.AddOptional("N", limit);

        var result = await _.RequestAsync<BitMartSpotMarginRepayWrapper>(_.BuildUri(BitMartApiSection.Spot, _spotV1MarginIsolatedRepayRecord), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<List<BitMartSpotMarginRepay>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Applicable for checking the borrowing rate and borrowing amount of trading pairs
    /// </summary>
    /// <param name="symbol">It can be multiple-choice; if not filled in, then return all, like BTC_USDT, ETH_USDT</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotMarginSymbol>>> GetSymbolsAsync(
        string symbol = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);

        var result = await _.RequestAsync<BitMartSpotMarginSymbolWrapper>(_.BuildUri(BitMartApiSection.Spot, _spotV1MarginIsolatedPairs), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<List<BitMartSpotMarginSymbol>>(result.Error);
        return result.As(result.Data.Payload);
    }
}