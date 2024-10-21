namespace BitMart.Api.Spot;

/// <summary>
/// BitMart Spot Rest API Client
/// </summary>
public class BitMartRestApiSpotClient
{
    /// <summary>
    /// System Status Client
    /// </summary>
    public BitMartRestApiSpotSystemClient System { get; }

    /// <summary>
    /// Public Market Data Client
    /// </summary>
    public BitMartRestApiSpotPublicClient Public { get; }

    /// <summary>
    /// Funding Account Data Client
    /// </summary>
    public BitMartRestApiSpotFundingClient Funding { get; }

    /// <summary>
    /// Spot/Margin Trading Client
    /// </summary>
    public BitMartRestApiSpotTradingClient Trading { get; }

    /// <summary>
    /// Margin Loan Client
    /// </summary>
    public BitMartRestApiSpotMarginClient Margin { get; }

    /// <summary>
    /// Sub-Account Client
    /// </summary>
    public BitMartRestApiSpotSubAccountClient SubAccount { get; }

    internal BitMartRestApiSpotClient(BitMartRestApiClient root)
    {
        System = new BitMartRestApiSpotSystemClient(root);
        Public = new BitMartRestApiSpotPublicClient(root);
        Funding = new BitMartRestApiSpotFundingClient(root);
        Trading = new BitMartRestApiSpotTradingClient(root);
        Margin = new BitMartRestApiSpotMarginClient(root);
        SubAccount = new BitMartRestApiSpotSubAccountClient(root);
    }
}