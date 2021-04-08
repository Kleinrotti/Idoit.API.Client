using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit.Response
{
    public sealed class IdoitVersionLoginResponse
    {
        [JsonProperty("userid")]
        public string userId { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("mail")]
        public string mail { get; set; }

        [JsonProperty("username")]
        public string userName { get; set; }

        [JsonProperty("mandator")]
        public string mandator { get; set; }

        [JsonProperty("language")]
        public string language { get; set; }
    }
}