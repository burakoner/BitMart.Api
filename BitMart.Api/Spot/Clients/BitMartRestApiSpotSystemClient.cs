namespace BitMart.Api.Spot;

/// <summary>
/// BitMart Spot System Rest API Client
/// </summary>
public class BitMartRestApiSpotSystemClient
{
    // Endpoints
    private const string _systemTime = "system/time";
    private const string _systemService = "system/service";

    // Internal
    internal BitMartRestApiClient _ { get; }
    internal BitMartRestApiSpotSystemClient(BitMartRestApiClient root) => _ = root;

    /// <summary>
    /// Get System Time
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<DateTime>> GetTimeAsync(CancellationToken ct = default)
    {
        var result = await _.RequestAsync<BitMartSpotSystemTime>(_.BuildUri(BitMartApiSection.Spot, _systemTime), HttpMethod.Get, ct).ConfigureAwait(false);
        if (!result) return result.AsError<DateTime>(result.Error);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get System Service Status
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<RestCallResult<List<BitMartSpotSystemStatus>>> GetStatusAsync(CancellationToken ct = default)
    {
        var result = await _.RequestAsync<BitMartSpotSystemStatusWrapper>(_.BuildUri(BitMartApiSection.Spot, _systemService), HttpMethod.Get, ct).ConfigureAwait(false);
        if (!result) return result.AsError<List<BitMartSpotSystemStatus>>(result.Error);
        return result.As(result.Data.Payload);
    }

}