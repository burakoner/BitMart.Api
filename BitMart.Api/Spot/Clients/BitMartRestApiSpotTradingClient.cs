namespace BitMart.Api.Spot;

/// <summary>
/// BitMart Spot Trading Rest API Client
/// </summary>
public class BitMartRestApiSpotTradingClient
{
    // Endpoints
    private const string _spotV2SubmitOrder = "spot/v2/submit_order";
    private const string _spotV3CancelOrder = "spot/v3/cancel_order";
    private const string _spotV4BatchOrders = "spot/v4/batch_orders";
    private const string _spotV4CancelOrders = "v4/cancel_orders";
    private const string _spotV4CancelAll = "spot/v4/cancel_all";
    private const string _spotV1MarginSubmitOrder = "spot/v1/margin/submit_order";
    private const string _spotV4QueryOrder = "spot/v4/query/order";
    private const string _spotV4QueryClientOrder = "spot/v4/query/client-order";
    private const string _spotV4QueryOpenOrders = "spot/v4/query/open-orders";
    private const string _spotV4QueryHistoryOrders = "spot/v4/query/history-orders";
    private const string _spotV4QueryTrades = "spot/v4/query/trades";
    private const string _spotV4QueryOrderTrades = "spot/v4/query/order-trades";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiSpotTradingClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Send in a new order.
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BTC_USDT)</param>
    /// <param name="side">Side</param>
    /// <param name="type">Order type</param>
    /// <param name="size">Order size</param>
    /// <param name="price">Price</param>
    /// <param name="quoteQuantity">Required for placing orders by amount</param>
    /// <param name="clientOrderId">Client-defined OrderId(A combination of numbers and letters, less than 32 bits)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<long>> PlaceOrderAsync(
        string symbol,
        BitMartSpotOrderSide side,
        BitMartSpotOrderType type,
        decimal? size = null,
        decimal? price = null,
        decimal? quoteQuantity = null,
        string clientOrderId = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
        };
        parameters.AddEnum("side", side);
        parameters.AddEnum("type", type);
        parameters.AddOptionalString("size", size);
        parameters.AddOptionalString("price", price);
        parameters.AddOptionalString("notional", quoteQuantity);
        parameters.AddOptional("client_order_id", clientOrderId);

        var result = await _.RequestAsync<BitMartSpotTradingOrderId>(_.BuildUri(BitMartApiSection.Spot, _spotV2SubmitOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
        if (!result) return result.AsError<long>(result.Error);
        return result.As(result.Data.OrderId);
    }

    /// <summary>
    /// Applicable to the cancellation of a specified unfinished order
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="orderId">Order ID</param>
    /// <param name="clientOrderId">Client-defined Order ID</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<bool>> CancelOrderAsync(
        string symbol,
        long? orderId = null,
        string clientOrderId = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
        };
        parameters.AddOptionalString("order_id", orderId);
        parameters.AddOptional("client_order_id", clientOrderId);

        var result = await _.RequestAsync<BitMartSpotTradingBooleanResult>(_.BuildUri(BitMartApiSection.Spot, _spotV3CancelOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
        if (!result) return result.AsError<bool>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Place multiple orders at once
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BTC_USDT)</param>
    /// <param name="orders">Order parameters, the number of transactions cannot exceed 10</param>
    /// <param name="receiveWindow">Trade time limit, allowed range (0,60000], default: 5000 milliseconds</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<long>>> PlaceOrdersAsync(
        string symbol,
        IEnumerable<BitMartTradingOrderRequest> orders,
        int? receiveWindow = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
            { "orderParams", orders },
        };
        parameters.AddOptional("recvWindow", receiveWindow.HasValue
            ? receiveWindow.Value
            : Convert.ToInt32(((BitMartRestApiClientOptions)_.ClientOptions).ReceiveWindow.TotalMilliseconds));

        var result = await _.RequestAsync<BitMartSpotTradingOrderIds>(_.BuildUri(BitMartApiSection.Spot, _spotV4BatchOrders), HttpMethod.Post, ct, true, bodyParameters: parameters);
        if (!result) return result.AsError<List<long>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Cancel all outstanding orders in the specified direction for the specified trading pair or cancel based on the order ID
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BTC_USDT)</param>
    /// <param name="orderIds">Order Id List (Either orderIds or clientOrderIds must be provided)</param>
    /// <param name="clientOrderIds">Client-defined OrderId List (Either orderIds or clientOrderIds must be provided)</param>
    /// <param name="receiveWindow">Trade time limit, allowed range (0,60000], default: 5000 milliseconds</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotTradingCancelOrders>> CancelOrdersAsync(
        string symbol,
        IEnumerable<long> orderIds = null,
        IEnumerable<string> clientOrderIds = null,
        int? receiveWindow = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
        };
        parameters.AddOptional("orderIds", orderIds);
        parameters.AddOptional("clientOrderIds", clientOrderIds);
        parameters.AddOptional("recvWindow", receiveWindow.HasValue
            ? receiveWindow.Value
            : Convert.ToInt32(((BitMartRestApiClientOptions)_.ClientOptions).ReceiveWindow.TotalMilliseconds));

        return _.RequestAsync<BitMartSpotTradingCancelOrders>(_.BuildUri(BitMartApiSection.Spot, _spotV4CancelOrders), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Cancel all orders
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BTC_USDT)</param>
    /// <param name="side">Order side</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotTradingCancelOrders>> CancelAllOrdersAsync(
        string symbol = null,
        BitMartSpotOrderSide? side = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("side", side);

        return _.RequestAsync<BitMartSpotTradingCancelOrders>(_.BuildUri(BitMartApiSection.Spot, _spotV4CancelAll), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Applicable for margin order placement
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BTC_USDT)</param>
    /// <param name="side">Side</param>
    /// <param name="type">Order type</param>
    /// <param name="size">Order size</param>
    /// <param name="price">Price</param>
    /// <param name="quoteQuantity">Required for placing orders by amount</param>
    /// <param name="clientOrderId">Client-defined OrderId(A combination of numbers and letters, less than 32 bits)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<long>> PlaceMarginOrderAsync(
        string symbol,
        BitMartSpotOrderSide side,
        BitMartSpotOrderType type,
        decimal? size = null,
        decimal? price = null,
        decimal? quoteQuantity = null,
        string clientOrderId = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
        };
        parameters.AddEnum("side", side);
        parameters.AddEnum("type", type);
        parameters.AddOptionalString("size", size);
        parameters.AddOptionalString("price", price);
        parameters.AddOptionalString("notional", quoteQuantity);
        parameters.AddOptional("client_order_id", clientOrderId);

        var result = await _.RequestAsync<BitMartSpotTradingOrderId>(_.BuildUri(BitMartApiSection.Spot, _spotV1MarginSubmitOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
        if (!result) return result.AsError<long>(result.Error);
        return result.As(result.Data.OrderId);
    }

    /// <summary>
    /// Query a single order by orderId or clientOrderId
    /// </summary>
    /// <param name="orderId">Order Id</param>
    /// <param name="clientOrderId">Client Order Id</param>
    /// <param name="state">Query Type</param>
    /// <param name="receiveWindow">Trade time limit, allowed range (0,60000], default: 5000 milliseconds</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotTradingOrder>> GetOrderAsync(
        long? orderId = null,
        string clientOrderId = null,
        BitMartSpotQueryState? state = null,
        int? receiveWindow = null,
        CancellationToken ct = default)
    {
        if (orderId == null && string.IsNullOrEmpty(clientOrderId))
            throw new ArgumentException("Either orderId or clientOrderId must be provided");
        if (orderId != null && !string.IsNullOrEmpty(clientOrderId))
            throw new ArgumentException("Either orderId or clientOrderId must be provided, not both");

        var parameters = new ParameterCollection
        {
            { "orderId", orderId.HasValue ? orderId : clientOrderId },
        };
        parameters.AddOptionalEnum("queryState", state);
        parameters.AddOptional("recvWindow", receiveWindow.HasValue
            ? receiveWindow.Value
            : Convert.ToInt32(((BitMartRestApiClientOptions)_.ClientOptions).ReceiveWindow.TotalMilliseconds));

        return _.RequestAsync<BitMartSpotTradingOrder>(_.BuildUri(BitMartApiSection.Spot, orderId.HasValue ? _spotV4QueryOrder : _spotV4QueryClientOrder), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Query the current opening order list of the account, only including state=[new, partially_filled] orders
    /// For high-volume trades, it is strongly recommended that users maintain their own current order list and use websocket to update the order status. You should pull the current order list once before each transaction.
    /// symbol is not filled in, all trading pairs will be searched by default
    /// orderMode is not filled in, and all order modes are searched by default
    /// limit is not filled, the default is 200, if it is filled, it cannot exceed 200
    /// If the time range startTime and endTime are not filled in, the data of the last 7 days will be displayed by default.
    /// When filling in the time range, endTime must be greater than the value of startTime.
    /// If only startTime is filled in, query the historical records starting from this timestamp.
    /// If only endTime is filled in, query the historical records starting from this timestamp.
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BTC_USDT)</param>
    /// <param name="mode">Order mode</param>
    /// <param name="startTime">Start time in milliseconds, (e.g. 1681701557927)</param>
    /// <param name="endTime">End time in milliseconds, (e.g. 1681701557927)</param>
    /// <param name="limit">Number of queries, allowed range [1,200], default 200</param>
    /// <param name="receiveWindow">Trade time limit, allowed range (0,60000], default: 5000 milliseconds</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartSpotTradingOrder>>> GetOpenOrdersAsync(
        string symbol = null,
        BitMartSpotOrderMode? mode = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        int? receiveWindow = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("orderMode", mode);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("recvWindow", receiveWindow.HasValue
            ? receiveWindow.Value
            : Convert.ToInt32(((BitMartRestApiClientOptions)_.ClientOptions).ReceiveWindow.TotalMilliseconds));

        return _.RequestAsync<List<BitMartSpotTradingOrder>>(_.BuildUri(BitMartApiSection.Spot, _spotV4QueryOpenOrders), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Query the account history order list, only including state=[filled, canceled, partially_canceled] orders
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BTC_USDT)</param>
    /// <param name="mode">Order mode</param>
    /// <param name="startTime">Start time in milliseconds, (e.g. 1681701557927)</param>
    /// <param name="endTime">End time in milliseconds, (e.g. 1681701557927)</param>
    /// <param name="limit">Number of queries, allowed range [1,200], default 200</param>
    /// <param name="receiveWindow">Trade time limit, allowed range (0,60000], default: 5000 milliseconds</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartSpotTradingOrder>>> GetOrdersAsync(
        string symbol = null,
        BitMartSpotOrderMode? mode = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        int? receiveWindow = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("orderMode", mode);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("recvWindow", receiveWindow.HasValue
            ? receiveWindow.Value
            : Convert.ToInt32(((BitMartRestApiClientOptions)_.ClientOptions).ReceiveWindow.TotalMilliseconds));

        return _.RequestAsync<List<BitMartSpotTradingOrder>>(_.BuildUri(BitMartApiSection.Spot, _spotV4QueryHistoryOrders), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Query all transaction records of the account
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BTC_USDT)</param>
    /// <param name="mode">Order mode</param>
    /// <param name="startTime">Start time in milliseconds, (e.g. 1681701557927)</param>
    /// <param name="endTime">End time in milliseconds, (e.g. 1681701557927)</param>
    /// <param name="limit">Number of queries, allowed range [1,200], default 200</param>
    /// <param name="receiveWindow">Trade time limit, allowed range (0,60000], default: 5000 milliseconds</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartSpotTradingTrade>>> GetTradesAsync(
        string symbol = null,
        BitMartSpotOrderMode? mode = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        int? receiveWindow = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("orderMode", mode);
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("recvWindow", receiveWindow.HasValue
            ? receiveWindow.Value
            : Convert.ToInt32(((BitMartRestApiClientOptions)_.ClientOptions).ReceiveWindow.TotalMilliseconds));

        return _.RequestAsync<List<BitMartSpotTradingTrade>>(_.BuildUri(BitMartApiSection.Spot, _spotV4QueryTrades), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Query all transaction records of a single order
    /// </summary>
    /// <param name="orderId">Order id</param>
    /// <param name="receiveWindow">Trade time limit, allowed range (0,60000], default: 5000 milliseconds</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartSpotTradingTrade>>> GetTradesAsync(
        long orderId,
        int? receiveWindow = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("orderId", orderId);
        parameters.AddOptional("recvWindow", receiveWindow.HasValue
            ? receiveWindow.Value
            : Convert.ToInt32(((BitMartRestApiClientOptions)_.ClientOptions).ReceiveWindow.TotalMilliseconds));

        return _.RequestAsync<List<BitMartSpotTradingTrade>>(_.BuildUri(BitMartApiSection.Spot, _spotV4QueryOrderTrades), HttpMethod.Get, ct, true, queryParameters: parameters);
    }
}