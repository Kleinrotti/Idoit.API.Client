using Idoit.API.Client.Contants;
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Objects
{
    public class IdoitObjectsResult
    {
        [JsonProperty("id")]
        public int id { get; internal set; }

        [JsonProperty("title")]
        public string title { get; internal set; }

        [JsonProperty("sysid")]
        public string sysId { get; internal set; }

        [JsonProperty("type")]
        public string type { get; internal set; }

        [JsonProperty("type_title")]
        public string typeTitle { get; internal set; }

        [JsonProperty("typeGroupTitle")]
        public string type_group_title { get; internal set; }

        [JsonProperty("status")]
        public IdoitStatusTypes status { get; internal set; }

        [JsonProperty("cmdb_status")]
        public IdoitCmdbStatus cmdbStatus { get; internal set; }

        [JsonProperty("cmdbStatusTitle")]
        public string cmdb_status_title { get; internal set; }

        [JsonProperty("created")]
        public string created { get; internal set; }

        [JsonProperty("updated")]
        public string updated { get; internal set; }

        [JsonProperty("image")]
        public string image { get; internal set; }
    }
}