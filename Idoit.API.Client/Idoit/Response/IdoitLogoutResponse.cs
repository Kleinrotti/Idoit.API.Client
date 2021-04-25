using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit
{
    /// <summary>
    /// Represents a response from idoit when logging out.
    /// </summary>
    public sealed class IdoitLogoutResponse
    {
        [JsonProperty("message")]
        public string message { get; internal set; }

        [JsonProperty("result")]
        public bool result { get; internal set; }
    }
}