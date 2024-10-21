namespace BitMart.Api.Common;

internal class BitMartAuthenticationProvider : AuthenticationProvider
{
    public BitMartAuthenticationProvider(BitMartApiCredentials credentials) : base(credentials)
    {
        if (credentials == null || credentials.Key == null || credentials.Secret == null || string.IsNullOrEmpty(credentials.Memo))
            throw new ArgumentException("No valid API credentials provided. Key/Secret/Memo needed.");
    }

    public override void AuthenticateRestApi(
        RestApiClient apiClient,
        Uri uri,
        HttpMethod method,
        bool signed,
        ArraySerialization serialization,
        SortedDictionary<string, object> query,
        SortedDictionary<string, object> body,
        string bodyContent,
        SortedDictionary<string, string> headers)
    {
        // Options
        var options = (BitMartRestApiClientOptions)apiClient.ClientOptions;

        // Check Point
        if (!signed && !options.SignPublicRequests)
            return;

        // Credentials
        var credentials = (BitMartApiCredentials)Credentials;

        // Check Point
        if (credentials == null || credentials.Key == null || credentials.Secret == null || string.IsNullOrEmpty(credentials.Memo))
            throw new ArgumentException("No valid API credentials provided. Key/Secret/Memo needed.");

        // Set Uri
        uri = uri.SetParameters(query, serialization);

        // Time
        var timeOffset = ((BitMartRestApiClient)apiClient).TimeSyncState.TimeOffset;
        var serverTime = DateTime.UtcNow.Add(timeOffset);

        // Signature
        var memo = credentials.Memo;
        var apikey = credentials.Key.GetString();
        var timestamp = serverTime.ConvertToMilliseconds().ToString();
        var signtext = string.Empty;
        if (query != null) signtext += query.ToFormData();
        if (!string.IsNullOrEmpty(bodyContent)) signtext += bodyContent;
        signtext = $"{timestamp}#{memo}#{signtext}";
        var signature = SignHMACSHA256(signtext, SignatureOutputType.Hex).ToLowerInvariant();

        // Headers
        headers ??= [];
        headers.Add("X-BM-KEY", apikey);
        headers.Add("X-BM-SIGN", signature);
        headers.Add("X-BM-TIMESTAMP", timestamp);
        headers.Add("X-BM-BROKER-ID", BitMartApiConstants.BrokerId);
    }

    public string StreamApiSignature(string payload) => SignHMACSHA256(payload).ToLower();
    public static string Base64Encode(byte[] plainBytes) => Convert.ToBase64String(plainBytes);
    public static string Base64Encode(string plainText) => Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
    public static string Base64Decode(string base64EncodedData) => Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
}
