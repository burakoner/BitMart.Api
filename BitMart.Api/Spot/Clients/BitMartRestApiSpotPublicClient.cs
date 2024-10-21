namespace BitMart.Api.Spot;

/// <summary>
/// BitMart Spot System Rest API Client
/// </summary>
public class BitMartRestApiSpotPublicClient
{
    // Endpoints
    private const string _spotV1Currencies = "spot/v1/currencies";
    private const string _spotV1Symbols = "spot/v1/symbols"; // NOTE: Useless
    private const string _spotV1SymbolsDetails = "spot/v1/symbols/details";
    private const string _spotQuotationV3Tickers = "spot/quotation/v3/tickers";
    private const string _spotQuotationV3Ticker = "spot/quotation/v3/ticker";
    private const string _spotQuotationV3LiteKlines = "spot/quotation/v3/lite-klines";
    private const string _spotQuotationV3Klines = "spot/quotation/v3/klines";
    private const string _spotQuotationV3Books = "spot/quotation/v3/books";
    private const string _spotQuotationV3Trades = "spot/quotation/v3/trades";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiSpotPublicClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Get a list of all cryptocurrencies on the platform
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotPublicCurrency>>> GetCurrenciesAsync(CancellationToken ct = default)
    {
        var result = await _.RequestAsync<BitMartSpotPublicCurrencyWrapper>(_.BuildUri(BitMartApiSection.Spot, _spotV1Currencies), HttpMethod.Get, ct).ConfigureAwait(false);
        if (!result) return result.AsError<List<BitMartSpotPublicCurrency>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get a detailed list of all trading pairs on the platform
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotPublicSymbol>>> GetSymbolsAsync(CancellationToken ct = default)
    {
        var result = await _.RequestAsync<BitMartSpotPublicSymbolWrapper>(_.BuildUri(BitMartApiSection.Spot, _spotV1SymbolsDetails), HttpMethod.Get, ct).ConfigureAwait(false);
        if (!result) return result.AsError<List<BitMartSpotPublicSymbol>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get all trading pairs with a volume greater than 0 within 24 hours. Market data includes: latest transaction price, best bid price, best ask price and 24-hour transaction volume snapshot information. Note that the interface is not real-time data, if you need real-time data, please use websocket to subscribe Ticker channel
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotPublicTicker>>> GetTickersAsync(CancellationToken ct = default)
    {
        var result = await _.RequestAsync<List<BitMartSpotPublicTickers>>(_.BuildUri(BitMartApiSection.Spot, _spotQuotationV3Tickers), HttpMethod.Get, ct).ConfigureAwait(false);
        if (!result) return result.AsError<List<BitMartSpotPublicTicker>>(result.Error);
        return result.As(result.Data.Select(t => t.ToTicker()).ToList());
    }

    /// <summary>
    /// Applicable to query the aggregated market price of a certain trading pair, and return the latest ticker information. Note that the interface is not real-time data, if you need real-time data, please use websocket to subscribe Ticker channel
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotPublicTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection { { "symbol", symbol } };
        return _.RequestAsync<BitMartSpotPublicTicker>(_.BuildUri(BitMartApiSection.Spot, _spotQuotationV3Ticker), HttpMethod.Get, ct, false, queryParameters: parameters);
    }

    /// <summary>
    /// Query the latest K-line and return a maximum of 1000 data. Note that the latest K-line of the interface is not real-time data. If you want real-time data, please use websocket to subscribe to K-line channel
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="interval">k-line step</param>
    /// <param name="before">Query timestamp (unit: second, e.g. 1525760116), query the data before this time</param>
    /// <param name="after">Query timestamp (unit: second, e.g. 1525769116), query the data after this time</param>
    /// <param name="limit">Return number, the maximum value is 200, default is 100</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartSpotPublicKline>>> GetKlinesAsync(
        string symbol,
        BitMartSpotKlineInterval interval,
        long? before = null,
        long? after = null,
        int? limit = null,
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 200);

        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
        };
        parameters.AddOptionalEnum("step", interval);
        parameters.AddOptional("before", before);
        parameters.AddOptional("after", after);
        parameters.AddOptional("limit", limit);

        return _.RequestAsync<List<BitMartSpotPublicKline>>(_.BuildUri(BitMartApiSection.Spot, _spotQuotationV3LiteKlines), HttpMethod.Get, ct, false, queryParameters: parameters);
    }
    
    /// <summary>
    /// Get k-line data within a specified time range of a specified trading pair. Note that the interface is not real-time data, if you need real-time data, please use websocket to subscribe KLine channel
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="interval">k-line step</param>
    /// <param name="before">Query timestamp (unit: second, e.g. 1525760116), query the data before this time</param>
    /// <param name="after">Query timestamp (unit: second, e.g. 1525769116), query the data after this time</param>
    /// <param name="limit">Return number, the maximum value is 200, default is 100</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartSpotPublicKline>>> GetKlinesHistoryAsync(
        string symbol,
        BitMartSpotKlineInterval interval,
        long? before = null,
        long? after = null,
        int? limit = null,
        CancellationToken ct = default)
    {
        limit?.ValidateIntBetween(nameof(limit), 1, 200);

        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
        };
        parameters.AddOptionalEnum("step", interval);
        parameters.AddOptional("before", before);
        parameters.AddOptional("after", after);
        parameters.AddOptional("limit", limit);

        return _.RequestAsync<List<BitMartSpotPublicKline>>(_.BuildUri(BitMartApiSection.Spot, _spotQuotationV3Klines), HttpMethod.Get, ct, false, queryParameters: parameters);
    }

    /// <summary>
    /// Get full depth of trading pairs. Note that the interface is not real-time data, if you need real-time data, please use websocket to subscribe Depth channel
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="limit">Order book depth per side. Maximum 50, e.g. 50 bids + 50 asks. Default returns to 35 depth data, e.g. 35 bids + 35 asks.</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotPublicOrderBook>> GetOrderBookAsync(
        string symbol,
        int? limit = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
        };
        parameters.AddOptional("limit", limit);

        return _.RequestAsync<BitMartSpotPublicOrderBook>(_.BuildUri(BitMartApiSection.Spot, _spotQuotationV3Books), HttpMethod.Get, ct, false, queryParameters: parameters);
    }

    /// <summary>
    /// Get the latest trade records of the specified trading pair. Note that the interface is not real-time data, if you need real-time data, please use websocket to subscribe Trade channel
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="limit">Number of returned items, maximum is 50, default 50</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartSpotPublicTrade>>> GetTradesAsync(
        string symbol,
        int? limit = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
        };
        parameters.AddOptional("limit", limit);

        return _.RequestAsync<List<BitMartSpotPublicTrade>>(_.BuildUri(BitMartApiSection.Spot, _spotQuotationV3Trades), HttpMethod.Get, ct, false, queryParameters: parameters);
    }
}