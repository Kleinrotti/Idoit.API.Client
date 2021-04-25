using Idoit.API.Client.Contants;
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Object
{
    /// <summary>
    /// Represents an object which will be received when reading an object from idoit.
    /// </summary>
    public sealed class IdoitObjectResult
    {
        [JsonProperty("id")]
        public int id { get; internal set; }

        [JsonProperty("title")]
        public string title { get; internal set; }

        [JsonProperty("sysid")]
        public string sysId { get; internal set; }

        [JsonProperty("objecttype")]
        public string objectType { get; internal set; }

        [JsonProperty("type_title")]
        public string typeTitle { get; internal set; }

        [JsonProperty("type_icon")]
        public string typeIcon { get; internal set; }

        [JsonProperty("status")]
        public IdoitStatusTypes status { get; internal set; }

        [JsonProperty("cmdb_status")]
        public string cmdbStatus { get; internal set; }

        [JsonProperty("cmdb_status_title")]
        public string cmdbStatusTitle { get; internal set; }

        [JsonProperty("created")]
        public string created { get; internal set; }

        [JsonProperty("updated")]
        public string updated { get; internal set; }

        [JsonProperty("image")]
        public string image { get; internal set; }
    }
}