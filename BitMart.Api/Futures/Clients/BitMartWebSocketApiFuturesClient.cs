namespace BitMart.Api.Futures;

/// <summary>
/// BitMart Futures WebSocket API Client
/// </summary>
public class BitMartWebSocketApiFuturesClient
{
    // Internal
    internal BitMartWebSocketApiClient _ { get; }
    internal BitMartWebSocketApiFuturesClient(BitMartWebSocketApiClient root) => _ = root;

    /// <summary>
    /// Get the latest transaction price, bid one price, ask for one price, and 24 trading volumes of all perpetual contracts on the platform
    /// </summary>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTickersAsync(Action<BitMartFuturesSocketTickerUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<BitMartFuturesSocketTickerUpdate>>>(data =>
        {
            if (data.Data is not null)
                handler(data.Data.Payload);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Futures, false), new BitMartWebSocketRequest()
        {
            Action = "subscribe",
            Parameters = ["futures/ticker"]
        }, _.NextIdentifier(), false, internalHandler, ct);
    }

    /// <summary>
    /// Get depth data
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="level">Depth Level</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToDepthAsync(string symbol, int level, Action<BitMartFuturesSocketOrderBookUpdate> handler, CancellationToken ct = default)
        => SubscribeToDepthAsync([symbol], level, handler, ct);

    /// <summary>
    /// Get depth data
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="level">Depth Level</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToDepthAsync(IEnumerable<string> symbols, int level, Action<BitMartFuturesSocketOrderBookUpdate> handler, CancellationToken ct = default)
    {
        level.ValidateIntValues(nameof(level), 5, 20, 50);

        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<BitMartFuturesSocketOrderBookUpdate>>>(data =>
        {
            if (data.Data is null
            || data.Data.Payload is null) return;

            handler(data.Data.Payload);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Futures, false), new BitMartWebSocketRequest()
        {
            Action = "subscribe",
            Parameters = symbols.Select(x => $"futures/depth{level}:{x}")
        }, _.NextIdentifier(), false, internalHandler, ct);
    }

    /// <summary>
    /// Get trade data
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTradesAsync(string symbol, Action<BitMartFuturesSocketTradeUpdate> handler, CancellationToken ct = default)
        => SubscribeToTradesAsync([symbol], handler, ct);

    /// <summary>
    /// Get trade data
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToTradesAsync(IEnumerable<string> symbols, Action<BitMartFuturesSocketTradeUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartFuturesSocketTradeUpdate>>>>(data =>
        {
            if (data.Data is null
            || data.Data.Payload is null) return;

            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Futures, false), new BitMartWebSocketRequest()
        {
            Action = "subscribe",
            Parameters = symbols.Select(x => $"futures/trade:{x}")
        }, _.NextIdentifier(), false, internalHandler, ct);
    }

    /// <summary>
    /// Get individual contract K-line data
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="interval">Kline Interval</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToKlinesAsync(string symbol, BitMartFuturesKlineInterval interval, Action<BitMartFuturesSocketKlineUpdate> handler, CancellationToken ct = default)
        => SubscribeToKlinesAsync([symbol], interval, handler, ct);

    /// <summary>
    /// Get individual contract K-line data
    /// </summary>
    /// <param name="symbols">Symbols</param>
    /// <param name="interval">Kline Interval</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToKlinesAsync(IEnumerable<string> symbols, BitMartFuturesKlineInterval interval, Action<BitMartFuturesSocketKlineUpdate> handler, CancellationToken ct = default)
    {
        var maps = MapConverter.GetStrings(interval);
        if (maps.Count < 2) throw new ArgumentException("Unsupported Kline Interval", nameof(interval));

        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<BitMartFuturesSocketKlineUpdate>>>(data =>
        {
            if (data.Data is null
            || data.Data.Payload is null) return;

            handler(data.Data.Payload);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Futures, false), new BitMartWebSocketRequest()
        {
            Action = "subscribe",
            Parameters = symbols.Select(x => $"futures/klineBin{maps[1]}:{x}")
        }, _.NextIdentifier(), false, internalHandler, ct);
    }
    
    /// <summary>
    /// Get asset balance change
    /// </summary>
    /// <param name="asset">Asset</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToBalancesAsync(string asset, Action<BitMartFuturesSocketBalanceUpdate> handler, CancellationToken ct = default)
        => SubscribeToBalancesAsync([asset], handler, ct);

    /// <summary>
    /// Get asset balance change
    /// </summary>
    /// <param name="assets">Assets</param>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToBalancesAsync(IEnumerable<string> assets, Action<BitMartFuturesSocketBalanceUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<BitMartFuturesSocketBalanceUpdate>>>(data =>
        {
            if (data.Data is null
            || data.Data.Payload is null) return;

            handler(data.Data.Payload);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Futures, true), new BitMartWebSocketRequest()
        {
            Action = "subscribe",
            Parameters = assets.Select(x => $"futures/asset:{x}")
        }, _.NextIdentifier(), false, internalHandler, ct);
    }

    /// <summary>
    /// Get Position Data
    /// </summary>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToPositionsAsync(Action<BitMartFuturesSocketPositionUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartFuturesSocketPositionUpdate>>>>(data =>
        {
            if (data.Data is null
            || data.Data.Payload is null) return;

            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Futures, true), new BitMartWebSocketRequest()
        {
            Action = "subscribe",
            Parameters = ["futures/position"]
        }, _.NextIdentifier(), false, internalHandler, ct);
    }

    /// <summary>
    /// Order Channel, which pushes immediately when the order status, transaction amount, etc. changes.
    /// </summary>
    /// <param name="handler">Data Handler</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<CallResult<WebSocketUpdateSubscription>> SubscribeToOrdersAsync(Action<BitMartFuturesSocketOrderUpdate> handler, CancellationToken ct = default)
    {
        var internalHandler = new Action<WebSocketDataEvent<BitMartWebSocketApiResponse<List<BitMartFuturesSocketOrderUpdate>>>>(data =>
        {
            if (data.Data is null
            || data.Data.Payload is null) return;

            foreach (var d in data.Data.Payload)
                if (d is not null) handler(d);
        });

        return _.Subscribe(_.GetAddress(BitMartApiSection.Futures, true), new BitMartWebSocketRequest()
        {
            Action = "subscribe",
            Parameters = ["futures/order"]
        }, _.NextIdentifier(), false, internalHandler, ct);
    }
}
