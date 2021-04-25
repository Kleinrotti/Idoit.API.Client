using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit
{
    public sealed class IdoitVersionResponse
    {
        public IdoitVersionLoginResponse login { get; set; }

        [JsonProperty("version")]
        public string version { get; internal set; }

        [JsonProperty("step")]
        public string step { get; internal set; }

        [JsonProperty("type")]
        public string type { get; internal set; }
    }
}