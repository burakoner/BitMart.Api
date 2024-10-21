namespace BitMart.Api.Spot;

/// <summary>
/// BitMart Spot Funding Rest API Client
/// </summary>
public class BitMartRestApiSpotFundingClient
{
    // Endpoints
    private const string _accountV1Wallet = "account/v1/wallet";
    private const string _accountV1Currencies = "account/v1/currencies";
    private const string _spotV1Wallet = "spot/v1/wallet";
    private const string _accountV1DepositAddress = "account/v1/deposit/address";
    private const string _accountV1WithdrawCharge = "account/v1/withdraw/charge";
    private const string _accountV1WithdrawApply = "account/v1/withdraw/apply";
    private const string _accountV2DepositWithdrawHistory = "account/v2/deposit-withdraw/history";
    private const string _accountV1DepositWithdrawDetail = "account/v1/deposit-withdraw/detail";
    private const string _spotV1MarginIsolatedAccount = "spot/v1/margin/isolated/account";
    private const string _spotV1MarginIsolatedTransfer = "spot/v1/margin/isolated/transfer";
    private const string _spotV1UserFee = "spot/v1/user_fee";
    private const string _spotV1TradeFee = "spot/v1/trade_fee";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiSpotFundingClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Gets Account Balance
    /// </summary>
    /// <param name="currency">currency</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotFundingBalance>>> GetAccountBalancesAsync(string currency = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", currency);

        var result = await _.RequestAsync<BitMartSpotFundingBalanceWrapper>(_.BuildUri(BitMartApiSection.Spot, _accountV1Wallet), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<List<BitMartSpotFundingBalance>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Gets the currency of the asset for withdrawal
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotFundingCurrency>>> GetCurrenciesAsync(CancellationToken ct = default)
    {
        var result = await _.RequestAsync<BitMartSpotFundingCurrencyWrapper>(_.BuildUri(BitMartApiSection.Spot, _accountV1Currencies), HttpMethod.Get, ct, true);
        if (!result) return result.AsError<List<BitMartSpotFundingCurrency>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get the user's wallet balance for all currencies
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotFundingBalance>>> GetSpotBalancesAsync(CancellationToken ct = default)
    {
        var result = await _.RequestAsync<BitMartSpotFundingBalanceWrapper>(_.BuildUri(BitMartApiSection.Spot, _spotV1Wallet), HttpMethod.Get, ct, true);
        if (!result) return result.AsError<List<BitMartSpotFundingBalance>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Gets Deposit Address
    /// </summary>
    /// <param name="currency">Token symbol, e.g., 'BTC'</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotFundingAddress>> GetDepositAddressAsync(string currency, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", currency);

        return _.RequestAsync<BitMartSpotFundingAddress>(_.BuildUri(BitMartApiSection.Spot, _accountV1DepositAddress), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Query withdraw quota for currencies
    /// </summary>
    /// <param name="currency">Token symbol, e.g., 'BTC'</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotFundingWithdrawalQuota>> GetWithdrawQuotaAsync(string currency, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("currency", currency);

        return _.RequestAsync<BitMartSpotFundingWithdrawalQuota>(_.BuildUri(BitMartApiSection.Spot, _accountV1WithdrawCharge), HttpMethod.Get, ct, true, queryParameters: parameters);
    }

    /// <summary>
    /// Creates a withdraw request from spot account to an external address
    /// The API can only make withdrawal to verified addresses, and verified addresses can be set by WEB/APP.
    /// </summary>
    /// <param name="currency">Token symbol, e.g., 'BTC'</param>
    /// <param name="amount">The amount of currency to withdraw</param>
    /// <param name="address">Withdraw address (only the address added on the official website is supported)</param>
    /// <param name="memo">Address tag(tag Or payment_id Or memo)</param>
    /// <param name="destination">Remark</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<long>> WithdrawToBlockchainAsync(
        string currency,
        decimal amount,
        string address,
        string memo = "",
        string destination = "",
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("currency", currency);
        parameters.AddString("amount", amount);
        parameters.Add("address", address);
        parameters.AddOptional("address_memo", memo);
        parameters.AddOptional("destination", destination);

        var result = await _.RequestAsync<BitMartSpotFundingWithdrawId>(_.BuildUri(BitMartApiSection.Spot, _accountV1WithdrawApply), HttpMethod.Post, ct, true, bodyParameters: parameters);
        if (!result) return result.AsError<long>(result.Error);
        return result.As(result.Data.WithdrawId);
    }


    /// <summary>
    /// Creates a withdraw request from spot account to an external address
    /// The API can only make withdrawal to verified addresses, and verified addresses can be set by WEB/APP.
    /// </summary>
    /// <param name="currency">Token symbol, e.g., 'BTC'</param>
    /// <param name="amount">The amount of currency to withdraw</param>
    /// <param name="type">Account type
    /// 1=CID
    /// 2=Email
    /// 3=Phone</param>
    /// <param name="value">Account</param>
    /// <param name="areaCode">Phone area code, required when account type is phone, e.g.: 61</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<long>> WithdrawToBitMartAsync(
        string currency,
        decimal amount,
        BitMartSpotWithdrawalAccount type,
        string value,
        string areaCode = null,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("currency", currency);
        parameters.AddString("amount", amount);
        parameters.AddEnum("type", type);
        parameters.Add("value", value);
        parameters.AddOptional("areaCode", areaCode);

        var result = await _.RequestAsync<BitMartSpotFundingWithdrawId>(_.BuildUri(BitMartApiSection.Spot, _accountV1WithdrawApply), HttpMethod.Post, ct, true, bodyParameters: parameters);
        if (!result) return result.AsError<long>(result.Error);
        return result.As(result.Data.WithdrawId);
    }

    /// <summary>
    /// The original /account/v1/deposit-withdraw/history interface, the old interface is no longer supported, please switch to the new interface as soon as possible
    /// Search for all existed withdraws and deposits and return their latest status.
    /// </summary>
    /// <param name="currency">Token symbol, e.g., 'BTC'</param>
    /// <param name="type">type</param>
    /// <param name="limit">Recent N records (value range 1-100)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotFundingTransaction>>> GetTransactionsAsync(
        string currency,
        BitMartSpotTransactionType type,
        int limit = 100,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("currency", currency);
        parameters.AddEnum("operation_type", type);
        parameters.Add("N", limit);

        var result = await _.RequestAsync<BitMartSpotFundingTransactionHistory>(_.BuildUri(BitMartApiSection.Spot, _accountV2DepositWithdrawHistory), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<List<BitMartSpotFundingTransaction>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Query a single charge record
    /// </summary>
    /// <param name="id">withdraw_id or deposit_id</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<BitMartSpotFundingTransaction>> GetTransactionAsync(long id, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("id", id);

        var result = await _.RequestAsync<BitMartSpotFundingTransactionWrapper>(_.BuildUri(BitMartApiSection.Spot, _accountV1DepositWithdrawDetail), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<BitMartSpotFundingTransaction>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Applicable for isolated margin account inquiries
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT), no symbol is passed, and all isolated margin assets are returned</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotFundingMarginAccount>>> GetMarginBalanceAsync(string symbol = null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("symbol", symbol);

        var result = await _.RequestAsync<BitMartSpotFundingMarginAccountWrapper>(_.BuildUri(BitMartApiSection.Spot, _spotV1MarginIsolatedAccount), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<List<BitMartSpotFundingMarginAccount>>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// For fund transfers between a margin account and spot account
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="currency">Currency</param>
    /// <param name="amount">Amount of transfers (precision: 8 decimal places)</param>
    /// <param name="side">Transfer direction</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<long>> MarginTransferAsync(
        string symbol,
        string currency,
        decimal amount,
        BitMartSpotMarginTransferSide side,
        CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("symbol", symbol);
        parameters.Add("currency", currency);
        parameters.AddString("amount", amount);
        parameters.AddEnum("side", side);

        var result = await _.RequestAsync<BitMartSpotFundingTransferId>(_.BuildUri(BitMartApiSection.Spot, _spotV1MarginIsolatedTransfer), HttpMethod.Get, ct, true, queryParameters: parameters);
        if (!result) return result.AsError<long>(result.Error);
        return result.As(result.Data.TransferId);
    }

    /// <summary>
    /// For querying the base rate of the current user
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotFundingBasicFeeRate>> GetBasicFeeRatesAsync(CancellationToken ct = default)
    {
        return _.RequestAsync<BitMartSpotFundingBasicFeeRate>(_.BuildUri(BitMartApiSection.Spot, _spotV1UserFee), HttpMethod.Get, ct, true);
    }

    /// <summary>
    /// For the actual fee rate of the trading pairs
    /// </summary>
    /// <param name="symbol">Trading pair (e.g. BMX_USDT)</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public Task<RestCallResult<BitMartSpotFundingTradeFeeRate>> GetTradeFeeRatesAsync(string symbol, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.Add("symbol", symbol);

        return _.RequestAsync<BitMartSpotFundingTradeFeeRate>(_.BuildUri(BitMartApiSection.Spot, _spotV1TradeFee), HttpMethod.Get, ct, true, queryParameters: parameters);
    }
}