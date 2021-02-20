using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class Assigned : IdoitAttribute
    {
        [JsonProperty("connector_type")]
        public string connectorType { get; set; }

        [JsonProperty("con_type")]
        public string conType { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("sysId")]
        public string sysid { get; set; }

        [JsonProperty("assigned_category")]
        public string assignedCategory { get; set; }
    }
}