namespace BitMart.Api.Futures;

/// <summary>
/// BitMart Sub-Account Rest API Client
/// </summary>
public class BitMartRestApiFuturesSubAccountClient
{
    // Endpoints
    private const string _accountContractSubAccountMainV1SubToMain = "account/contract/sub-account/main/v1/sub-to-main";
    private const string _accountContractSubAccountMainV1MainToSub = "account/contract/sub-account/main/v1/main-to-sub";
    private const string _accountContractSubAccountSubV1SubToMain = "account/contract/sub-account/sub/v1/sub-to-main";
    private const string _accountContractSubAccountMainV1Wallet = "account/contract/sub-account/main/v1/wallet";
    private const string _accountContractSubAccountMainV1TransferList = "account/contract/sub-account/main/v1/transfer-list";
    private const string _accountContractSubAccountV1TransferHistory = "account/contract/sub-account/v1/transfer-history";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiFuturesSubAccountClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Sub-account futures asset transfer to Main-account futures asset (For Main Account)
    /// </summary>
    /// <param name="requestNo">UUID,unique identifier, max length 64</param>
    /// <param name="amount">Transfer amount</param>
    /// <param name="currency">Currency</param>
    /// <param name="subAccount">Sub-Account username</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<object>> SubAccountToMainAccountAsync(
        string requestNo,
        decimal amount,
        string currency,
        string subAccount,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "requestNo", requestNo },
            { "currency", currency },
            { "subAccount", subAccount },
        };
        parameters.AddString("amount", amount);

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Futures, _accountContractSubAccountMainV1SubToMain), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Main-account futures asset transfer to Sub-account futures asset (For Main Account)
    /// </summary>
    /// <param name="requestNo">UUID,unique identifier, max length 64</param>
    /// <param name="amount">Transfer amount</param>
    /// <param name="currency">Currency</param>
    /// <param name="subAccount">Sub-Account username</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<object>> MainAccountToSubAccountAsync(
        string requestNo,
        decimal amount,
        string currency,
        string subAccount,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "requestNo", requestNo },
            { "currency", currency },
            { "subAccount", subAccount },
        };
        parameters.AddString("amount", amount);

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Futures, _accountContractSubAccountMainV1MainToSub), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Sub-Account futures asset transfer to Main-Account futures asset (For Sub-Account)
    /// </summary>
    /// <param name="requestNo">UUID,unique identifier, max length 64</param>
    /// <param name="amount">Transfer amount</param>
    /// <param name="currency">Currency</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<object>> SubAccountToMainAccountAsync(
        string requestNo,
        decimal amount,
        string currency,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "requestNo", requestNo },
            { "currency", currency },
        };
        parameters.AddString("amount", amount);

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Futures, _accountContractSubAccountSubV1SubToMain), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Get Sub-Account futures wallet balance (For Main Account) (KEYED)
    /// </summary>
    /// <param name="subAccount">Sub-Account username</param>
    /// <param name="currency">Currency</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartFuturesSubAccountBalance>>> GetSubAccountBalancesAsync(
        string subAccount,
        string currency = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "subAccount", subAccount },
        };
        parameters.AddOptional("currency", currency);

        var result = await _.RequestAsync<BitMartFuturesSubAccountBalanceWrapper>(_.BuildUri(BitMartApiSection.Futures, _accountContractSubAccountMainV1Wallet), HttpMethod.Get, ct, true, bodyParameters: parameters);
        if (!result) return result.AsError<List<BitMartFuturesSubAccountBalance>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query Sub-Account Futures Asset Transfer History (For Main Account)
    /// </summary>
    /// <param name="subAccount">Sub-Account username</param>
    /// <param name="limit">Recent N records, allowed range[1,100]</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartFuturesSubAccountTransfer>>> GetSubAccountTransfersAsync(
        string subAccount,
        int limit = 100,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "subAccount", "subAccount" },
            { "N", limit },
        };

        return _.RequestAsync<List<BitMartFuturesSubAccountTransfer>>(_.BuildUri(BitMartApiSection.Futures, _accountContractSubAccountMainV1TransferList), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Get account Futures asset transfer history (For Main/Sub Account)
    /// </summary>
    /// <param name="limit">Recent N records, allowed range[1,100]</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<List<BitMartFuturesSubAccountTransfer>>> GetSubAccountAssetTransfersAsync(
        int limit = 100,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "limit", limit },
        };

        return _.RequestAsync<List<BitMartFuturesSubAccountTransfer>>(_.BuildUri(BitMartApiSection.Futures, _accountContractSubAccountV1TransferHistory), HttpMethod.Get, ct, true, queryParameters: parameters);
    }
}