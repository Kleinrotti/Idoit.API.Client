using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit.Response
{
    public class IdoitLogoutResponse
    {
        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("result")]
        public bool result { get; set; }
    }
}