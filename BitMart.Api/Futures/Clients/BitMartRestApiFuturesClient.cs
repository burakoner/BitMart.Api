namespace BitMart.Api.Futures;

/// <summary>
/// BitMart Futures Rest API Client
/// </summary>
public class BitMartRestApiFuturesClient
{
    /// <summary>
    /// Public Rest API Client
    /// </summary>
    public BitMartRestApiFuturesPublicClient Public { get; }

    /// <summary>
    /// Account Rest API Client
    /// </summary>
    public BitMartRestApiFuturesAccountClient Account { get; }

    /// <summary>
    /// Trading Rest API Client
    /// </summary>
    public BitMartRestApiFuturesTradingClient Trading { get; }

    /// <summary>
    /// SubAccount Rest API Client
    /// </summary>
    public BitMartRestApiFuturesSubAccountClient SubAccount { get; }

    internal BitMartRestApiFuturesClient(BitMartRestApiClient root)
    {
        Public = new BitMartRestApiFuturesPublicClient(root);
        Account = new BitMartRestApiFuturesAccountClient(root);
        Trading = new BitMartRestApiFuturesTradingClient(root);
        SubAccount = new BitMartRestApiFuturesSubAccountClient(root);
    }
}