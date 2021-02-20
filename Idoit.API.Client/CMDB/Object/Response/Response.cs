using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Object.Response
{
    public class Response
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("success")]
        public bool success { get; set; }
    }
}