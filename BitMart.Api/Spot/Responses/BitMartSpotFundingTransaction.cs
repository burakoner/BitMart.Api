namespace BitMart.Api.Spot;

internal record BitMartSpotFundingTransactionWrapper
{
    [JsonProperty("record")]
    public BitMartSpotFundingTransaction Payload { get; set; }
}


internal record BitMartSpotFundingTransactionHistory
{
    [JsonProperty("records")]
    public List<BitMartSpotFundingTransaction> Payload { get; set; } = [];
}

/// <summary>
/// BitMartSpotFundingTransaction
/// </summary>
public record BitMartSpotFundingTransaction
{
    /// <summary>
    /// Withdraw id
    /// </summary>
    [JsonProperty("withdraw_id")]
    public long? WithdrawId { get; set; }

    /// <summary>
    /// Deposit id
    /// </summary>
    [JsonProperty("deposit_id")]
    public long? DepositId { get; set; }

    /// <summary>
    /// Operation type
    /// </summary>
    [JsonProperty("operation_type")]
    public BitMartSpotTransactionType OperationType { get; set; }

    /// <summary>
    /// Currency
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Apply time
    /// </summary>
    [JsonProperty("apply_time")]
    public DateTime ApplyTime { get; set; }

    /// <summary>
    /// Arrival quantity
    /// </summary>
    [JsonProperty("arrival_amount")]
    public decimal ArrivalQuantity { get; set; }

    /// <summary>
    /// Fee
    /// </summary>
    [JsonProperty("fee")]
    public decimal Fee { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    [JsonProperty("status")]
    public BitMartSpotTransactionStatus Status { get; set; }

    /// <summary>
    /// Address
    /// </summary>
    [JsonProperty("address")]
    public string Address { get; set; }

    /// <summary>
    /// Address memo
    /// </summary>
    [JsonProperty("address_memo")]
    public string AddressMemo { get; set; }

    /// <summary>
    /// Transaction id
    /// </summary>
    [JsonProperty("tx_id")]
    public string TransactionId { get; set; }
}
