namespace BitMart.Api.Examples;

internal class Program
{
    static async Task Main(string[] args)
    {
        // Rest API Client
        var api = new BitMartRestApiClient();
        api.SetApiCredentials("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX", "XXXXXXXX-MEMO-XXXXXXXX");

        // Spot System Methods
        var system_01 = await api.Spot.System.GetTimeAsync(/* optional parameters */);
        var system_02 = await api.Spot.System.GetStatusAsync(/* optional parameters */);

        // Spot Public Methods
        var public_01 = await api.Spot.Public.GetCurrenciesAsync(/* optional parameters */);
        var public_02 = await api.Spot.Public.GetSymbolsAsync(/* optional parameters */);
        var public_03 = await api.Spot.Public.GetTickersAsync(/* optional parameters */);
        var public_04 = await api.Spot.Public.GetTickerAsync("BTC_USDT" /* optional parameters */);
        var public_05 = await api.Spot.Public.GetKlinesAsync("BTC_USDT", BitMartSpotKlineInterval.FourHours /* optional parameters */);
        var public_06 = await api.Spot.Public.GetKlinesHistoryAsync("BTC_USDT", BitMartSpotKlineInterval.FourHours /* optional parameters */);
        var public_07 = await api.Spot.Public.GetOrderBookAsync("BTC_USDT" /* optional parameters */);
        var public_08 = await api.Spot.Public.GetTradesAsync("BTC_USDT" /* optional parameters */);

        // Spot Funding Methods
        var funding_01 = await api.Spot.Funding.GetAccountBalancesAsync(/* optional parameters */);
        var funding_02 = await api.Spot.Funding.GetCurrenciesAsync(/* optional parameters */);
        var funding_03 = await api.Spot.Funding.GetSpotBalancesAsync(/* optional parameters */);
        var funding_04 = await api.Spot.Funding.GetDepositAddressAsync("USDT" /* optional parameters */);
        var funding_05 = await api.Spot.Funding.GetDepositAddressAsync("USDT-TRC20" /* optional parameters */);
        var funding_06 = await api.Spot.Funding.GetWithdrawQuotaAsync("USDT-TRC20" /* optional parameters */);
        var funding_07 = await api.Spot.Funding.WithdrawToBlockchainAsync("USDT", 100.0m, "-----ADDRESS-----" /* optional parameters */);
        var funding_08 = await api.Spot.Funding.WithdrawToBitMartAsync("USDT", 100.0m, BitMartSpotWithdrawalAccount.Email, "-----ADDRESS-----" /* optional parameters */);
        var funding_09 = await api.Spot.Funding.GetTransactionsAsync("USDT", BitMartSpotTransactionType.Deposit /* optional parameters */);
        var funding_10 = await api.Spot.Funding.GetTransactionAsync(1_000_0001L /* optional parameters */);
        var funding_11 = await api.Spot.Funding.GetMarginBalanceAsync(/* optional parameters */);
        var funding_12 = await api.Spot.Funding.MarginTransferAsync("SYMBOL", "CURRENCY", 100.0M, BitMartSpotMarginTransferSide.TransferIn /* optional parameters */);
        var funding_13 = await api.Spot.Funding.GetBasicFeeRatesAsync(/* optional parameters */);
        var funding_14 = await api.Spot.Funding.GetTradeFeeRatesAsync("BTC_USDT"/* optional parameters */);

        // Spot Trading Methods
        var trading_01 = await api.Spot.Trading.PlaceOrderAsync("BMX_USDT", BitMartSpotOrderSide.Buy, BitMartSpotOrderType.Market, quoteQuantity: 100.0m /* optional parameters */);
        var trading_02 = await api.Spot.Trading.CancelOrderAsync("BMX_USDT", 1_000_0001L /* optional parameters */);
        var trading_03 = await api.Spot.Trading.PlaceOrdersAsync("BMX_USDT", [] /* optional parameters */);
        var trading_04 = await api.Spot.Trading.CancelOrdersAsync("BMX_USDT", [], [] /* optional parameters */);
        var trading_05 = await api.Spot.Trading.CancelAllOrdersAsync(/* optional parameters */);
        var trading_06 = await api.Spot.Trading.CancelAllOrdersAsync("BMX_USDT" /* optional parameters */);
        var trading_07 = await api.Spot.Trading.PlaceMarginOrderAsync("BMX_USDT", BitMartSpotOrderSide.Buy, BitMartSpotOrderType.Market, quoteQuantity: 100.0m /* optional parameters */);
        var trading_08 = await api.Spot.Trading.GetOrderAsync(1_000_0001L /* optional parameters */);
        var trading_09 = await api.Spot.Trading.GetOpenOrdersAsync(/* optional parameters */);
        var trading_10 = await api.Spot.Trading.GetOpenOrdersAsync("BMX_USDT"/* optional parameters */);
        var trading_11 = await api.Spot.Trading.GetOrdersAsync(/* optional parameters */);
        var trading_12 = await api.Spot.Trading.GetOrdersAsync("BMX_USDT" /* optional parameters */);
        var trading_13 = await api.Spot.Trading.GetTradesAsync("BMX_USDT" /* optional parameters */);
        var trading_14 = await api.Spot.Trading.GetTradesAsync(1_000_0001L /* optional parameters */);

        // Spot Margin Methods
        var margin_01 = await api.Spot.Margin.BorrowAsync("BMX_USDT", "USDT", 100.0M /* optional parameters */);
        var margin_02 = await api.Spot.Margin.RepayAsync("BMX_USDT", "USDT", 100.0M /* optional parameters */);
        var margin_03 = await api.Spot.Margin.GetBorrowsAsync("BMX_USDT" /* optional parameters */);
        var margin_04 = await api.Spot.Margin.GetRepaysAsync("BMX_USDT" /* optional parameters */);
        var margin_05 = await api.Spot.Margin.GetSymbolsAsync(/* optional parameters */);

        // Spot Sub-Account Methods
        var subaccount_01 = await api.Spot.SubAccount.SubAccountToMainAccountAsync("-----REQUEST-NUM-----", 100.0M, "CURRENCY" /* optional parameters */);
        var subaccount_02 = await api.Spot.SubAccount.SubAccountToMainAccountAsync("-----REQUEST-NUM-----", 100.0M, "CURRENCY", "SUB-ACCOUNT" /* optional parameters */);
        var subaccount_03 = await api.Spot.SubAccount.MainAccountToSubAccountAsync("-----REQUEST-NUM-----", 100.0M, "CURRENCY", "SUB-ACCOUNT" /* optional parameters */);
        var subaccount_04 = await api.Spot.SubAccount.SubAccountToSubAccountAsync("-----REQUEST-NUM-----", 100.0M, "CURRENCY", "FROM-ACCOUNT", "TO-ACCOUNT" /* optional parameters */);
        var subaccount_05 = await api.Spot.SubAccount.GetSubAccountTransfersAsync(/* optional parameters */);
        var subaccount_06 = await api.Spot.SubAccount.GetAccountSpotAssetTransfersAsync(/* optional parameters */);
        var subaccount_07 = await api.Spot.SubAccount.GetSubAccountTransfersAsync(/* optional parameters */);
        var subaccount_08 = await api.Spot.SubAccount.GetSubAccountsAsync(/* optional parameters */);

        // Futures Public Methods
        var public_101 = await api.Futures.Public.GetContractsAsync(/* optional parameters */);
        var public_102 = await api.Futures.Public.GetContractAsync("BTCUSDT" /* optional parameters */);
        var public_103 = await api.Futures.Public.GetOrderBookAsync("BTCUSDT" /* optional parameters */);
        var public_104 = await api.Futures.Public.GetOpenInterestAsync("BTCUSDT" /* optional parameters */);
        var public_105 = await api.Futures.Public.GetFundingRateAsync("BTCUSDT" /* optional parameters */);
        var public_106 = await api.Futures.Public.GetKlinesAsync("BTCUSDT", BitMartFuturesKlineInterval.FourHours, 1662518172, 1662518172 /* optional parameters */);

        // Futures Public Methods
        var account_101 = await api.Futures.Account.GetBalancesAsync(/* optional parameters */);

        // Futures Trading Methods
        var trading_101 = await api.Futures.Trading.GetTradeFeeRatesAsync("BTCUSDT" /* optional parameters */);
        var trading_102 = await api.Futures.Trading.GetOrderAsync("BTCUSDT", 1_000_001L /* optional parameters */);
        var trading_103 = await api.Futures.Trading.GetOrdersAsync("BTCUSDT" /* optional parameters */);
        var trading_104 = await api.Futures.Trading.GetOpenOrdersAsync(/* optional parameters */);
        var trading_105 = await api.Futures.Trading.GetOpenPlanOrdersAsync(/* optional parameters */);
        var trading_106 = await api.Futures.Trading.GetPositionsAsync(/* optional parameters */);
        var trading_107 = await api.Futures.Trading.GetPositionRisksAsync(/* optional parameters */);
        var trading_108 = await api.Futures.Trading.GetTradesAsync(/* optional parameters */);
        var trading_109 = await api.Futures.Trading.GetTransfersAsync(/* optional parameters */);
        var trading_110 = await api.Futures.Trading.PlaceOrderAsync(new BitMartFuturesTradingOrderRequest() /* optional parameters */);
        var trading_111 = await api.Futures.Trading.CancelOrderAsync("BTCUSDT" /* optional parameters */);
        var trading_112 = await api.Futures.Trading.CancelOrdersAsync("BTCUSDT" /* optional parameters */);
        var trading_113 = await api.Futures.Trading.PlacePlanOrderAsync(new BitMartFuturesTradingTriggerOrderRequest() /* optional parameters */);
        var trading_114 = await api.Futures.Trading.CancelPlanOrderAsync("BTCUSDT", 1_000_001L /* optional parameters */);
        var trading_115 = await api.Futures.Trading.TransferAsync("USDT", 100.0M, BitMartFuturesTransferType.SpotToContract /* optional parameters */);
        var trading_116 = await api.Futures.Trading.SetLeverageAsync("BTCUSDT", 10, BitMartFuturesMarginType.IsolatedMargin /* optional parameters */);
        var trading_117 = await api.Futures.Trading.PlaceTakeProfitStopLossAsync(new BitMartFuturesTradingTpSlOrderRequest() /* optional parameters */);
        var trading_118 = await api.Futures.Trading.ModifyPlanOrderAsync(new BitMartFuturesTradingTriggerOrderModifyRequest() /* optional parameters */);
        var trading_119 = await api.Futures.Trading.ModifyPresetPlanOrderAsync(new BitMartFuturesTradingTriggerOrderModifyPresetRequest() /* optional parameters */);
        var trading_120 = await api.Futures.Trading.ModifyTakeProfitStopLossOrderAsync(new BitMartFuturesTradingTpSlOrderModifyRequest() /* optional parameters */);

        // Futures Sub-Account Methods
        var subaccount_101 = await api.Futures.SubAccount.SubAccountToMainAccountAsync("-----REQUEST-NUM-----", 100.0M, "CURRENCY" /* optional parameters */);
        var subaccount_102 = await api.Futures.SubAccount.SubAccountToMainAccountAsync("-----REQUEST-NUM-----", 100.0M, "CURRENCY", "SUB-ACCOUNT" /* optional parameters */);
        var subaccount_103 = await api.Futures.SubAccount.MainAccountToSubAccountAsync("-----REQUEST-NUM-----", 100.0M, "CURRENCY", "SUB-ACCOUNT" /* optional parameters */);
        var subaccount_104 = await api.Futures.SubAccount.GetSubAccountBalancesAsync("SUB-ACCOUNT" /* optional parameters */);
        var subaccount_105 = await api.Futures.SubAccount.GetSubAccountTransfersAsync("SUB-ACCOUNT" /* optional parameters */);
        var subaccount_106 = await api.Futures.SubAccount.GetSubAccountAssetTransfersAsync(/* optional parameters */);

        // WebSocket API Client
        var wss = new BitMartWebSocketApiClient();
        wss.SetApiCredentials("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX", "XXXXXXXX-MEMO-XXXXXXXX");

        // WebSocket Spot Methods
        var wss_01 = await wss.Spot.SubscribeToTickersAsync("BTC_USDT", data =>
        {
            // Your code here
        });
        var wss_02 = await wss.Spot.SubscribeToTickersAsync(["BTC_USDT", "ETH_USDT"], data =>
        {
            // Your code here
        });
        var wss_03 = await wss.Spot.SubscribeToKlinesAsync("BTC_USDT", BitMartSpotKlineInterval.OneDay, data =>
        {
            // Your code here
        });
        var wss_04 = await wss.Spot.SubscribeToKlinesAsync(["BTC_USDT", "ETH_USDT"], BitMartSpotKlineInterval.OneDay, data =>
        {
            // Your code here
        });
        var wss_05 = await wss.Spot.SubscribeToDepthAllAsync("BTC_USDT", 5, data =>
        {
            // Your code here
        });
        var wss_06 = await wss.Spot.SubscribeToDepthAllAsync(["BTC_USDT", "ETH_USDT"], 5, data =>
        {
            // Your code here
        });
        var wss_07 = await wss.Spot.SubscribeToDepthIncreaseAsync("BTC_USDT", data =>
        {
            // Your code here
        });
        var wss_08 = await wss.Spot.SubscribeToDepthIncreaseAsync(["BTC_USDT", "ETH_USDT"], data =>
        {
            // Your code here
        });
        var wss_09 = await wss.Spot.SubscribeToTradesAsync("BTC_USDT", data =>
        {
            // Your code here
        });
        var wss_10 = await wss.Spot.SubscribeToTradesAsync(["BTC_USDT", "ETH_USDT"], data =>
        {
            // Your code here
        });
        var wss_11 = await wss.Spot.SubscribeToOrdersAsync(data =>
        {
            // Your code here
        });
        var wss_12 = await wss.Spot.SubscribeToOrdersAsync("BTC_USDT", data =>
        {
            // Your code here
        });
        var wss_13 = await wss.Spot.SubscribeToOrdersAsync(["BTC_USDT", "ETH_USDT"], data =>
        {
            // Your code here
        });
        var wss_14 = await wss.Spot.SubscribeToBalancesAsync(data =>
        {
            // Your code here
        });

        // WebSocket Futures Methods
        var wss_101 = await wss.Futures.SubscribeToTickersAsync(data =>
        {
            // Your code here
        });
        var wss_102 = await wss.Futures.SubscribeToDepthAsync("BTCUSDT", 5, data =>
        {
            // Your code here
        });
        var wss_103 = await wss.Futures.SubscribeToDepthAsync(["BTCUSDT", "ETHUSDT"], 5, data =>
        {
            // Your code here
        });
        var wss_104 = await wss.Futures.SubscribeToTradesAsync("BTCUSDT", data =>
        {
            // Your code here
        });
        var wss_105 = await wss.Futures.SubscribeToTradesAsync(["BTCUSDT", "ETHUSDT"], data =>
        {
            // Your code here
        });
        var wss_106 = await wss.Futures.SubscribeToKlinesAsync("BTC_USDT", BitMartFuturesKlineInterval.OneDay, data =>
        {
            // Your code here
        });
        var wss_107 = await wss.Futures.SubscribeToKlinesAsync(["BTC_USDT", "ETH_USDT"], BitMartFuturesKlineInterval.OneDay, data =>
        {
            // Your code here
        });
        var wss_108 = await wss.Futures.SubscribeToBalancesAsync("USDT", data =>
        {
            // Your code here
        });
        var wss_109 = await wss.Futures.SubscribeToBalancesAsync(["BTC", "ETH", "USDT"], data =>
        {
            // Your code here
        });
        var wss_110 = await wss.Futures.SubscribeToPositionsAsync(data =>
        {
            // Your code here
        });
        var wss_111 = await wss.Futures.SubscribeToOrdersAsync(data =>
        {
            // Your code here
        });

        // Unsubscribe
        await wss.UnsubscribeAllAsync();
        await wss.UnsubscribeAsync(wss_111.Data);
        await wss.UnsubscribeAsync(wss_111.Data.Id);
    }
}