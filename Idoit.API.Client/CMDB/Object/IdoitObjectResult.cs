using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Object
{
    /// <summary>
    /// Represents an object which will be received when reading an object from idoit.
    /// </summary>
    public sealed class IdoitObjectResult
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("sysid")]
        public string sysId { get; set; }

        [JsonProperty("objecttype")]
        public string objectType { get; set; }

        [JsonProperty("type_title")]
        public string typeTitle { get; set; }

        [JsonProperty("type_icon")]
        public string typeIcon { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("cmdb_status")]
        public string cmdbStatus { get; set; }

        [JsonProperty("cmdb_status_title")]
        public string cmdbStatusTitle { get; set; }

        [JsonProperty("created")]
        public string created { get; set; }

        [JsonProperty("updated")]
        public string updated { get; set; }

        [JsonProperty("image")]
        public string image { get; set; }
    }
}