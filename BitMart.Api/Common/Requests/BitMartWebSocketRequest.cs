namespace BitMart.Api.Common;

internal class BitMartWebSocketRequest
{
    [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
    public string Action { get; set; }

    [JsonProperty("op", NullValueHandling = NullValueHandling.Ignore)]
    public string Operation { get; set; }

    [JsonProperty("args")]
    public IEnumerable<string> Parameters { get; set; } = [];
    
    public bool HandleSubscriptionResponse(JToken data, ref bool forcedExit)
    {
        // Spot WebSocket
        if (data["event"] != null && data["topic"] != null)
        {
            forcedExit = false;
            var evt = (string)data["event"];
            var topic = (string)data["topic"];

            if (evt != "subscribe")
            {
                forcedExit = true;
                return false;
            }

            if (!Parameters.Contains(topic))
            {
                forcedExit = true;
                return false;
            }

            return true;
        }
        
        // Futures WebSocket
        if (data["action"] != null && data["group"] != null && data["success"] != null)
        {
            forcedExit = false;
            var act = (string)data["action"];
            var group = (string)data["group"];
            var success = (bool)data["success"];

            if (act != "subscribe")
            {
                forcedExit = true;
                return false;
            }

            if (!Parameters.Contains(group))
            {
                forcedExit = true;
                return false;
            }

            return success;
        }

        // Return
        return false;
    }

    public bool MessageMatchesHandler(JToken data)
    {
        // Spot WebSocket
        if (data["table"] != null)
        {
            var table = (string)data["table"];
            return Parameters.Any(x => table == x.Split(':').FirstOrDefault());
        }
        
        // Futures WebSocket
        if (data["group"] != null)
        {
            var group = (string)data["group"];
            return Parameters.Any(x => group == x);
        }

        // Return
        return false;
    }
}