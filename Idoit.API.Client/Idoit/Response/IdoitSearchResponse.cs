using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit.Response
{
    public class IdoitSearchResponse
    {
        [JsonProperty("documentId")]
        public string documentId { get; set; }

        [JsonProperty("key")]
        public string key { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("link")]
        public string link { get; set; }

        [JsonProperty("score")]
        public int score { get; set; }
    }
}