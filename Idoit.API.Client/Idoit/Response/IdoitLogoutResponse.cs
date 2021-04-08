using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit.Response
{
    /// <summary>
    /// Represents a response from idoit when logging out.
    /// </summary>
    public sealed class IdoitLogoutResponse
    {
        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("result")]
        public bool result { get; set; }
    }
}