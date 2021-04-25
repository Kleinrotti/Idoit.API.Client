using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit
{
    /// <summary>
    /// Represents a response from idoit when searching for objects.
    /// </summary>
    public sealed class IdoitSearchResponse
    {
        [JsonProperty("documentId")]
        public string documentId { get; internal set; }

        [JsonProperty("key")]
        public string key { get; internal set; }

        [JsonProperty("value")]
        public string value { get; internal set; }

        [JsonProperty("type")]
        public string type { get; internal set; }

        [JsonProperty("link")]
        public string link { get; internal set; }

        [JsonProperty("score")]
        public int score { get; internal set; }
    }
}