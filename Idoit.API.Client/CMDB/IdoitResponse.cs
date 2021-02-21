using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB
{
    public class IdoitResponse
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("success")]
        public bool success { get; set; }
    }
}