using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit.Response
{
    public class IdoitVersionResponse
    {
        public IdoitVersionLoginResponse login { get; set; }

        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("step")]
        public string step { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }
}