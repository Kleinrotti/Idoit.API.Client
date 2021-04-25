using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit
{
    /// <summary>
    /// Represents a response from idoit when logging in.
    /// </summary>
    public sealed class IdoitLoginResponse
    {
        [JsonProperty("result")]
        public bool result { get; internal set; }

        [JsonProperty("userid")]
        public string userId { get; internal set; }

        [JsonProperty("name")]
        public string name { get; internal set; }

        [JsonProperty("mail")]
        public string mail { get; internal set; }

        [JsonProperty("username")]
        public string userName { get; internal set; }

        [JsonProperty("session-id")]
        public string sessionId { get; internal set; }

        [JsonProperty("client-id")]
        public string clientId { get; internal set; }

        [JsonProperty("client-name")]
        public string clientName { get; internal set; }
    }
}