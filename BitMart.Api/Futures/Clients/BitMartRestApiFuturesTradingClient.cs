namespace BitMart.Api.Futures;

/// <summary>
/// BitMart Futures Trading Rest API Client
/// </summary>
public class BitMartRestApiFuturesTradingClient
{
    // Endpoints
    private const string _contractPrivateTradeFeeRate = "contract/private/trade-fee-rate";
    private const string _contractPrivateOrder = "contract/private/order";
    private const string _contractPrivateOrderHistory = "contract/private/order-history";
    private const string _contractPrivateGetOpenOrders = "contract/private/get-open-orders";
    private const string _contractPrivateCurrentPlanOrder = "contract/private/current-plan-order";
    private const string _contractPrivatePosition = "contract/private/position";
    private const string _contractPrivatePositionRisk = "contract/private/position-risk";
    private const string _contractPrivateTrades = "contract/private/trades";
    private const string _accountV1TransferContractList = "account/v1/transfer-contract-list";
    private const string _contractPrivateSubmitOrder = "contract/private/submit-order";
    private const string _contractPrivateCancelOrder = "contract/private/cancel-order";
    private const string _contractPrivateCancelOrders = "contract/private/cancel-orders";
    private const string _contractPrivateSubmitPlanOrder = "contract/private/submit-plan-order";
    private const string _contractPrivateCancelPlanOrder = "contract/private/cancel-plan-order";
    private const string _accountV1TransferContract = "account/v1/transfer-contract";
    private const string _contractPrivateSubmitLeverage = "contract/private/submit-leverage";
    private const string _contractPrivateSubmitTpSlOrder = "contract/private/submit-tp-sl-order";
    private const string _contractPrivateModifyPlanOrder = "contract/private/modify-plan-order";
    private const string _contractPrivateModifyPresetPlanOrder = "contract/private/modify-preset-plan-order";
    private const string _contractPrivateModifyTpSlOrder = "contract/private/modify-tp-sl-order";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiFuturesTradingClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Applicable for querying trade fee rate
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartFuturesTradingTradeFeeRate>>> GetTradeFeeRatesAsync(string symbol, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection {
            { "symbol", symbol }
        };

        return _.RequestAsync<List<BitMartFuturesTradingTradeFeeRate>>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateTradeFeeRate), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for querying contract order detail
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="orderId">Order ID</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesTradingOrder>> GetOrderAsync(
        string symbol,
        long orderId,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
            { "orderId", orderId },
        };

        return _.RequestAsync<BitMartFuturesTradingOrder>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateOrder), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for querying contract order history
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="startTime">Start time, default is the last 7 days</param>
    /// <param name="endTime">End time, default is the last 7 days</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartFuturesTradingOrder>>> GetOrdersAsync(
        string symbol,
        long? startTime = null,
        long? endTime = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "symbol", symbol },
        };
        parameters.AddOptional("startTime", startTime);
        parameters.AddOptional("endTime", endTime);

        return _.RequestAsync<List<BitMartFuturesTradingOrder>>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateOrderHistory), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for querying contract all open orders
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="type">Order type</param>
    /// <param name="justPartial"></param>
    /// <param name="limit"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartFuturesTradingOrder>>> GetOpenOrdersAsync(
        string symbol = null,
        BitMartFuturesOrderType? type = null,
        bool justPartial = false,
        int? limit = null,
        CancellationToken ct = default)
    {
        if (type != null &&
            type != BitMartFuturesOrderType.Limit &&
            type != BitMartFuturesOrderType.Market &&
            type != BitMartFuturesOrderType.Trailing)
            throw new ArgumentException("Unsupported Order Type");

        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("type", type);
        parameters.AddOptional("order_state", justPartial ? "partially_filled" : "all");
        parameters.AddOptional("limit", limit);

        return _.RequestAsync<List<BitMartFuturesTradingOrder>>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateGetOpenOrders), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for querying contract all plan orders
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="type">Order type
    /// - limit
    /// - market</param>
    /// <param name="planType">	Plan order type
    /// -plan
    /// - profit_loss
    /// default all</param>
    /// <param name="limit">The number of returned results, with a maximum of 100 and a default of 100</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public Task<RestCallResult<List<BitMartFuturesTradingOrder>>> GetOpenPlanOrdersAsync(
        string symbol = null,
        BitMartFuturesOrderType? type = null,
        BitMartFuturesTriggerPlanType? planType = null,
        int? limit = null,
        CancellationToken ct = default)
    {
        if (type != null &&
            type != BitMartFuturesOrderType.Limit &&
            type != BitMartFuturesOrderType.Market)
            throw new ArgumentException("Unsupported Order Type");

        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptionalEnum("type", type);
        parameters.AddOptionalEnum("plan_type", planType);
        parameters.AddOptional("limit", limit);

        return _.RequestAsync<List<BitMartFuturesTradingOrder>>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateCurrentPlanOrder), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for checking the position details a specified contract
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartFuturesTradingPosition>>> GetPositionsAsync(
        string symbol = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);

        return _.RequestAsync<List<BitMartFuturesTradingPosition>>(_.BuildUri(BitMartApiSection.Futures, _contractPrivatePosition), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for checking the position risk details a specified contract
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartFuturesTradingPositionRisk>>> GetPositionRisksAsync(
        string symbol = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);

        return _.RequestAsync<List<BitMartFuturesTradingPositionRisk>>(_.BuildUri(BitMartApiSection.Futures, _contractPrivatePositionRisk), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Applicable for querying contract order trade detail
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="startTime">Start time, default is the last 7 days</param>
    /// <param name="endTime">End time, default is the last 7 days</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartFuturesTradingTrade>>> GetTradesAsync(
        string symbol = null,
        long? startTime = null,
        long? endTime = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);
        parameters.AddOptional("start_time", startTime);
        parameters.AddOptional("end_time", endTime);

        return _.RequestAsync<List<BitMartFuturesTradingTrade>>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateTrades), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Query futures account transfer records
    /// </summary>
    /// <param name="currency">Currency (like USDT)</param>
    /// <param name="startTime">Start time in milliseconds, (e.g. 1681701557927)</param>
    /// <param name="endTime">End time in milliseconds, (e.g. 1681701557927)</param>
    /// <param name="page">Number of pages, allowed range [1,1000]</param>
    /// <param name="limit">Number of queries, allowed range [10,100]</param>
    /// <param name="receiveWindow">Trade time limit, allowed range (0,60000], default: 5000 milliseconds</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartFuturesTradingTransfer>>> GetTransfersAsync(
        string currency = null,
        long? startTime = null,
        long? endTime = null,
        int? page = null,
        int? limit = null,
        int? receiveWindow = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", currency);
        parameters.AddOptional("time_start", startTime);
        parameters.AddOptional("time_end", endTime);
        parameters.AddOptional("page", page);
        parameters.AddOptional("limit", limit);
        parameters.AddOptional("recvWindow", receiveWindow);

        var result = await _.RequestAsync<BitMartFuturesTradingTransferWrapper>(_.BuildUri(BitMartApiSection.Futures, _accountV1TransferContractList), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<List<BitMartFuturesTradingTransfer>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Applicable for placing contract orders
    /// </summary>
    /// <param name="request">Order Request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesTradingOrderResponse>> PlaceOrderAsync(
        BitMartFuturesTradingOrderRequest request,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.SetBody(request);

        return _.RequestAsync<BitMartFuturesTradingOrderResponse>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateSubmitOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Applicable for canceling a specific contract order
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT),（If not submitted order_id and client_order_id, cancel all orders under the symbol）</param>
    /// <param name="orderId">Order ID</param>
    /// <param name="clientOrderId">Client-defined OrderId</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<object>> CancelOrderAsync(
        string symbol,
        long? orderId = null,
        string clientOrderId = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("symbol", symbol);
        parameters.AddOptionalString("order_id", orderId);
        parameters.AddOptional("client_order_id", clientOrderId);

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateCancelOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Applicable for batch order cancellation under a particular contract
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<object>> CancelOrdersAsync(
        string symbol,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("symbol", symbol);

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateCancelOrders), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Applicable for placing contract plan orders
    /// </summary>
    /// <param name="request">Order Request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesTradingOrderId>> PlacePlanOrderAsync(
        BitMartFuturesTradingTriggerOrderRequest request,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.SetBody(request);

        return _.RequestAsync<BitMartFuturesTradingOrderId>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateSubmitPlanOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Applicable for canceling a specific contract plan order
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="orderId">Order ID</param>
    /// <param name="clientOrderId">Client Order ID</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<object>> CancelPlanOrderAsync(
        string symbol,
        long? orderId = null,
        string clientOrderId = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("symbol", symbol);
        parameters.AddOptionalString("order_id", orderId);
        parameters.AddOptional("client_order_id", clientOrderId);

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateCancelPlanOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Transfer between spot account and contract account
    /// </summary>
    /// <param name="currency">Currency (Only USDT is supported)</param>
    /// <param name="amount">Transfer amount，allowed range[0.01,10000000000]</param>
    /// <param name="type">Transfer type</param>
    /// <param name="receiveWindow">Trade time limit, allowed range (0,60000], default: 5000 milliseconds</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesTradingTransferResponse>> TransferAsync(
        string currency,
        decimal amount,
        BitMartFuturesTransferType type,
        int? receiveWindow = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("currency", currency);
        parameters.AddString("amount", amount);
        parameters.AddEnum("type", type);
        parameters.AddOptional("recvWindow", receiveWindow);

        return _.RequestAsync<BitMartFuturesTradingTransferResponse>(_.BuildUri(BitMartApiSection.Futures, _accountV1TransferContract), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Applicable for adjust contract leverage 
    /// </summary>
    /// <param name="symbol">Symbol of the contract(like BTCUSDT)</param>
    /// <param name="leverage">Order leverage</param>
    /// <param name="type">Open type, required at close position</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesTradingLeverage>> SetLeverageAsync(
        string symbol,
        decimal leverage,
        BitMartFuturesMarginType type,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("symbol", symbol);
        parameters.AddString("leverage", leverage);
        parameters.AddEnum("open_type", type);

        return _.RequestAsync<BitMartFuturesTradingLeverage>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateSubmitLeverage), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }
    
    /// <summary>
    /// Applicable for placing contract TP/SL orders
    /// </summary>
    /// <param name="request">Order Request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesTradingTpSlOrderResponse>> PlaceTakeProfitStopLossAsync(
        BitMartFuturesTradingTpSlOrderRequest request,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.SetBody(request);

        return _.RequestAsync<BitMartFuturesTradingTpSlOrderResponse>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateSubmitTpSlOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Applicable for modifying contract plan orders
    /// </summary>
    /// <param name="request">Order Request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesTradingOrderId>> ModifyPlanOrderAsync(
        BitMartFuturesTradingTriggerOrderModifyRequest request,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.SetBody(request);

        return _.RequestAsync<BitMartFuturesTradingOrderId>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateModifyPlanOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Applicable for modifying contract preset plan orders
    /// </summary>
    /// <param name="request">Order Request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesTradingOrderId>> ModifyPresetPlanOrderAsync(
        BitMartFuturesTradingTriggerOrderModifyPresetRequest request,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.SetBody(request);

        return _.RequestAsync<BitMartFuturesTradingOrderId>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateModifyPresetPlanOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Applicable for modifying TP/SL orders
    /// </summary>
    /// <param name="request">Order Request</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartFuturesTradingOrderId>> ModifyTakeProfitStopLossOrderAsync(
        BitMartFuturesTradingTpSlOrderModifyRequest request,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.SetBody(request);

        return _.RequestAsync<BitMartFuturesTradingOrderId>(_.BuildUri(BitMartApiSection.Futures, _contractPrivateModifyTpSlOrder), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

}
