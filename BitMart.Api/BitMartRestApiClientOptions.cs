﻿namespace BitMart.Api;

/// <summary>
/// BitMart Rest API Client Options
/// </summary>
public class BitMartRestApiClientOptions : RestApiClientOptions
{
    /// <summary>
    /// API Credentials
    /// </summary>
    public new BitMartApiCredentials ApiCredentials { get; set; }

    /// <summary>
    /// Receive Window 
    /// </summary>
    public TimeSpan ReceiveWindow { get; set; }

    /// <summary>
    /// Auto Timestamp
    /// </summary>
    public bool AutoTimestamp { get; set; }

    /// <summary>
    /// Auto Timestamp Recalculation Interval
    /// </summary>
    public TimeSpan AutoTimestampInterval { get; set; }

    /// <summary>
    /// Sign Public Requests
    /// </summary>
    public bool SignPublicRequests { get; set; } = false;

    /// <summary>
    /// Spot Rest API Address
    /// </summary>
    public string SpotAddress { get; set; }

    /// <summary>
    /// Futures Rest API Address
    /// </summary>
    public string FuturesAddress { get; set; }

    /// <summary>
    /// Creates an instance of BitMart Rest API Client Options
    /// </summary>
    public BitMartRestApiClientOptions() : this(null)
    {
        BaseAddress = BitMartAddress.MainNet.RestApiSpotAddress;
        SpotAddress = BitMartAddress.MainNet.RestApiSpotAddress;
        FuturesAddress = BitMartAddress.MainNet.RestApiFuturesAddress;
    }

    /// <summary>
    /// Creates an instance of BitMart Rest API Client Options
    /// </summary>
    /// <param name="credentials"></param>
    public BitMartRestApiClientOptions(BitMartApiCredentials credentials)
    {
        // API Credentials
        ApiCredentials = credentials;

        // Api Addresses
        BaseAddress = BitMartAddress.MainNet.RestApiSpotAddress;

        // Receive Window
        ReceiveWindow = TimeSpan.FromSeconds(30);

        // Auto Timestamp
        AutoTimestamp = true;
        AutoTimestampInterval = TimeSpan.FromHours(1);

        // Http Options
        HttpOptions = new HttpOptions
        {
            UserAgent = RestApiConstants.USER_AGENT,
            AcceptMimeType = RestApiConstants.JSON_CONTENT_HEADER,
            RequestTimeout = TimeSpan.FromSeconds(30),
            EncodeQueryString = true,
            BodyFormat = RestBodyFormat.Json,
        };

        // Rate Limiters
        RateLimiters = new List<IRateLimiter>
        {
            new RateLimiter()
            .AddTotalRateLimit(10, TimeSpan.FromSeconds(1), false)
            .AddPartialEndpointLimit("/v5/order/create", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/order/amend", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/order/cancel", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/order/cancel-all", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/order/create-batch", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/order/amend-batch", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/order/cancel-batch", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/order/realtime", 10, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/order/history", 10, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)

            .AddPartialEndpointLimit("/v5/position/list", 10, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/execution/list", 10, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/position/closed-pnl", 10, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/position/set-leverage", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/position/set-tpsl-mode", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/position/set-risk-limit", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/position/trading-stop", 10, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)

            .AddPartialEndpointLimit("/v5/account/wallet-balance", 10, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/account/fee-rate", 10, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)

            .AddPartialEndpointLimit("/v5/transfer/query-asset-info", 60, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/transfer/query-transfer-coin-list", 60, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/transfer/query-transfer-coin-list", 60, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/transfer/query-inter-transfer-list", 60, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/transfer/query-sub-member-list", 60, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/transfer/query-universal-transfer-list", 2, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/transfer/query-account-coins-balance", 2, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/deposit/query-record", 300, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/deposit/query-sub-member-record", 300, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/deposit/query-address", 300, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/deposit/query-sub-member-address", 300, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/deposit/query-record", 300, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/deposit/query-info", 2, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/exchange/order-record", 600, TimeSpan.FromSeconds(60), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/transfer/inter-transfer", 20, TimeSpan.FromSeconds(60), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/transfer/save-transfer-sub-member", 20, TimeSpan.FromSeconds(60), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/transfer/universal-transfer", 5, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/withdraw/create", 10, TimeSpan.FromSeconds(60), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/withdraw/cancel", 60, TimeSpan.FromSeconds(60), HttpMethod.Post, true, true)

            .AddPartialEndpointLimit("/v5/user/create-sub-member", 5, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/user/create-sub-api", 5, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/user/frozen-sub-member", 5, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/user/update-api", 5, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/user/update-sub-api", 5, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/user/delete-api", 5, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/user/delete-sub-api", 5, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/user/query-sub-members", 10, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/user/query-api", 10, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)

            .AddPartialEndpointLimit("/v5/spot-lever-token/order-record", 50, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/spot-lever-token/purchase", 20, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/spot-lever-token/redeem", 20, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)

            .AddPartialEndpointLimit("/v5/spot-cross-margin-trade/loan-info", 50, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/spot-cross-margin-trade/account", 50, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/spot-cross-margin-trade/orders", 50, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/spot-cross-margin-trade/repay-history", 50, TimeSpan.FromSeconds(1), HttpMethod.Get, true, true)
            .AddPartialEndpointLimit("/v5/spot-cross-margin-trade/loan", 20, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/spot-cross-margin-trade/repay", 20, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
            .AddPartialEndpointLimit("/v5/spot-cross-margin-trade/switch", 20, TimeSpan.FromSeconds(1), HttpMethod.Post, true, true)
        };
        RateLimitingBehavior = RateLimitingBehavior.Wait;
    }
}