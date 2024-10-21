namespace BitMart.Api.Spot;

/// <summary>
/// BitMart Spot WebSocket API Client
/// </summary>
public class BitMartWebSocketApiSpotClient
{
    // Internal
    internal BitMartWebSocketApiClient _ { get; }
    internal BitMartWebSocketApiSpotClient(BitMartWebSocketApiClient root) => _ = root;

    /// <summary>
    /// Get the latest price, bid price, ask price and 24-hour trading volume
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTickersAsync(string symbol, Action<BitMartSpotPublicTickerUpdate> handler, CancellationToken ct = default)
        => SubscribeToTickersAsync([symbol], handler, ct);

    /// <summary>
    /// Get the latest price, bid price, ask price and 24-hour trading volume
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTickersAsync(IEnumerable<string> symbols, Action<BitMartSpotPublicTickerUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartSpotPublicTickerUpdate>>>>(data =>
        {
            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Spot, false), new BitMartWebSocketRequest()
        {
            Operation = "subscribe",
            Parameters = symbols.Select(x => $"spot/ticker:{x}")
        }, _.NextIdentifier(), false, internalHandler, ct);
    }

    /// <summary>
    /// Get the spot K-line data
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="interval">Kline Interval</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToKlinesAsync(string symbol, BitMartSpotKlineInterval interval, Action<BitMartSpotPublicKlineUpdate> handler, CancellationToken ct = default)
        => SubscribeToKlinesAsync([symbol], interval, handler, ct);

    /// <summary>
    /// Get the latest price, bid price, ask price and 24-hour trading volume
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="interval">Kline Interval</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToKlinesAsync(IEnumerable<string> symbols, BitMartSpotKlineInterval interval, Action<BitMartSpotPublicKlineUpdate> handler, CancellationToken ct = default)
    {
        var maps = MapConverter.GetStrings(interval);
        if (maps.Count < 2) throw new ArgumentException("Unsupported Kline Interval", nameof(interval));

        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartSpotPublicKlineUpdate>>>>(data =>
        {
            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Spot, false), new BitMartWebSocketRequest()
        {
            Operation = "subscribe",
            Parameters = symbols.Select(x => $"spot/kline{maps[1]}:{x}")
        }, _.NextIdentifier(), false, internalHandler, ct);
    }

    /// <summary>
    /// Return depth data, each push is the full data
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="level">Depth Level</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToDepthAllAsync(string symbol, int level, Action<BitMartSpotPublicOrderBookUpdate> handler, CancellationToken ct = default)
        => SubscribeToDepthAllAsync([symbol], level, handler, ct);
    
    /// <summary>
    /// Return depth data, each push is the full data
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="level">Depth Level</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToDepthAllAsync(IEnumerable<string> symbols, int level, Action<BitMartSpotPublicOrderBookUpdate> handler, CancellationToken ct = default)
    {
        level.ValidateIntValues(nameof(level), 5, 20, 50);

        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartSpotPublicOrderBookUpdate>>>>(data =>
        {
            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Spot, false), new BitMartWebSocketRequest()
        {
            Operation = "subscribe",
            Parameters = symbols.Select(x => $"spot/depth{level}:{x}")
        }, _.NextIdentifier(), false, internalHandler, ct);
    }

    /// <summary>
    /// Return depth data, support the creation of a local full depth cache data
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToDepthIncreaseAsync(string symbol, Action<BitMartSpotPublicOrderBookIncrementalUpdate> handler, CancellationToken ct = default)
        => SubscribeToDepthIncreaseAsync([symbol], handler, ct);
    
    /// <summary>
    /// Return depth data, support the creation of a local full depth cache data
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToDepthIncreaseAsync(IEnumerable<string> symbols, Action<BitMartSpotPublicOrderBookIncrementalUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartSpotPublicOrderBookIncrementalUpdate>>>>(data =>
        {
            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Spot, false), new BitMartWebSocketRequest()
        {
            Operation = "subscribe",
            Parameters = symbols.Select(x => $"spot/depth/increase100:{x}")
        }, _.NextIdentifier(), false, internalHandler, ct);
    }
    
    /// <summary>
    /// Get the latest real-time transaction data
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTradesAsync(string symbol, Action<BitMartSpotPublicTradeUpdate> handler, CancellationToken ct = default)
        => SubscribeToTradesAsync([symbol], handler, ct);
    
    /// <summary>
    /// Get the latest real-time transaction data
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTradesAsync(IEnumerable<string> symbols, Action<BitMartSpotPublicTradeUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartSpotPublicTradeUpdate>>>>(data =>
        {
            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Spot, false), new BitMartWebSocketRequest()
        {
            Operation = "subscribe",
            Parameters = symbols.Select(x => $"spot/trade:{x}")
        }, _.NextIdentifier(), false, internalHandler, ct);
    }
    
    /// <summary>
    /// Subscribe to the order execution progress of a single trading pair, or you can subscribe to the order execution progress of all trading pairs at once.
    /// </summary>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrdersAsync(Action<BitMartSpotTradingOrderUpdate> handler, CancellationToken ct = default)
        => SubscribeToOrdersAsync(["ALL_SYMBOLS"], handler, ct);

    /// <summary>
    /// Subscribe to the order execution progress of a single trading pair, or you can subscribe to the order execution progress of all trading pairs at once.
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrdersAsync(string symbol, Action<BitMartSpotTradingOrderUpdate> handler, CancellationToken ct = default)
        => SubscribeToOrdersAsync([symbol], handler, ct);
    
    /// <summary>
    /// Subscribe to the order execution progress of a single trading pair, or you can subscribe to the order execution progress of all trading pairs at once.
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrdersAsync(IEnumerable<string> symbols, Action<BitMartSpotTradingOrderUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartSpotTradingOrderUpdate>>>>(data =>
        {
            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Spot, true), new BitMartWebSocketRequest()
        {
            Operation = "subscribe",
            Parameters = symbols.Select(x => $"spot/user/orders:{x}")
        }, _.NextIdentifier(), true, internalHandler, ct);
    }

    /// <summary>
    /// Balance change push
    /// </summary>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToBalancesAsync(Action<BitMartSpotFundingBalanceUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartSpotFundingBalanceUpdate>>>>(data =>
        {
            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Spot, true), new BitMartWebSocketRequest()
        {
            Operation = "subscribe",
            Parameters = ["spot/user/balance:BALANCE_UPDATE"]
        }, _.NextIdentifier(), true, internalHandler, ct);
    }
}