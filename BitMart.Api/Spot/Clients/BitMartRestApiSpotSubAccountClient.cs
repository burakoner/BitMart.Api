namespace BitMart.Api.Spot;

/// <summary>
/// BitMart Sub-Account Rest API Client
/// </summary>
public class BitMartRestApiSpotSubAccountClient
{
    // Endpoints
    private const string _accountSubAccountMainV1SubToMain = "account/sub-account/main/v1/sub-to-main";
    private const string _accountSubAccountSubV1SubToMain = "account/sub-account/sub/v1/sub-to-main";
    private const string _accountSubAccountMainV1MainToSub = "account/sub-account/main/v1/main-to-sub";
    private const string _accountSubAccountMainV1SubToSub = "account/sub-account/main/v1/sub-to-sub";
    private const string _accountSubAccountMainV1TransferList = "account/sub-account/main/v1/transfer-list";
    private const string _accountSubAccountV1TransferHistory = "account/sub-account/v1/transfer-history";
    private const string _accountSubAccountMainV1Wallet = "account/sub-account/main/v1/wallet";
    private const string _accountSubAccountMainV1SubAccountList = "account/sub-account/main/v1/subaccount-list";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiSpotSubAccountClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Sub-account spot asset transfer to Main-account (For Main Account)
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

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Spot, _accountSubAccountMainV1SubToMain), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Sub-Account spot asset transfer to Main-Account spot asset (For Sub-Account)
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

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Spot, _accountSubAccountSubV1SubToMain), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Main-account spot asset transfer to Sub-account spot asset (For Main Account)
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

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Spot, _accountSubAccountMainV1MainToSub), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Sub-Account spot asset transfer to Sub-Account spot asset (For Main Account)
    /// </summary>
    /// <param name="requestNo">UUID,unique identifier, max length 64</param>
    /// <param name="amount">Transfer amount</param>
    /// <param name="currency">Currency</param>
    /// <param name="fromAccount">Transfer out Sub-Account username</param>
    /// <param name="toAccount">Transfer to Sub-Account username</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<object>> SubAccountToSubAccountAsync(
        string requestNo,
        decimal amount,
        string currency,
        string fromAccount,
        string toAccount,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "requestNo", requestNo },
            { "currency", currency },
            { "fromAccount", fromAccount },
            { "toAccount", toAccount },
        };
        parameters.AddString("amount", amount);

        return _.RequestAsync<object>(_.BuildUri(BitMartApiSection.Spot, _accountSubAccountMainV1SubToSub), HttpMethod.Post, ct, true, bodyParameters: parameters);
    }

    /// <summary>
    /// Query Sub-Account Spot Asset Transfer History (For Main Account)
    /// </summary>
    /// <param name="accountName">Sub-Account username (default: all sub-accounts will be queried)</param>
    /// <param name="limit">Recent N records, allowed range[1,100]</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotSubAccountTransferHistory>> GetSubAccountTransfersAsync(
        string accountName = null,
        int limit = 100,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "moveType", "spot to spot" },
            { "N", limit },
        };
        parameters.AddOptional("accountName", accountName);

        return _.RequestAsync<BitMartSpotSubAccountTransferHistory>(_.BuildUri(BitMartApiSection.Spot, _accountSubAccountMainV1TransferList), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Get account spot asset transfer history (For Main/Sub Account)
    /// </summary>
    /// <param name="limit">Recent N records, allowed range[1,100]</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotSubAccountTransferHistory>> GetAccountSpotAssetTransfersAsync(
        int limit = 100,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "moveType", "spot to spot" },
            { "N", limit },
        };

        return _.RequestAsync<BitMartSpotSubAccountTransferHistory>(_.BuildUri(BitMartApiSection.Spot, _accountSubAccountV1TransferHistory), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Get Sub-Account spot wallet balance (For Main Account)
    /// </summary>
    /// <param name="subAccount">Sub-Account username</param>
    /// <param name="currency">Currency</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotSubAccountBalance>>> GetSubAccountTransfersAsync(
        string subAccount,
        string currency = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "subAccount", subAccount },
        };
        parameters.AddOptional("currency", currency);

        var result = await _.RequestAsync<BitMartSpotSubAccountBalanceWrapper>(_.BuildUri(BitMartApiSection.Spot, _accountSubAccountMainV1Wallet), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<List<BitMartSpotSubAccountBalance>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get Sub-Account list (For Main Account)
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotSubAccount>>> GetSubAccountsAsync(CancellationToken ct = default)
    {
        var result = await _.RequestAsync<BitMartSpotSubAccountWrapper>(_.BuildUri(BitMartApiSection.Spot, _accountSubAccountMainV1SubAccountList), HttpMethod.Get, ct, true);
        if (!result) return result.AsError<List<BitMartSpotSubAccount>>(result.Error);
        return result.As(result.Data.Payload);
    }
}