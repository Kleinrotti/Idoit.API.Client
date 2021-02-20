using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Objects.Response
{
    public class IdoitResponse
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("success")]
        public string success { get; set; }
    }
}