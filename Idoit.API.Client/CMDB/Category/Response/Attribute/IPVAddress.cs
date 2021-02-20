using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class IPVAddress : IdoitAttribute
    {
        [JsonProperty("sysid")]
        public string sysId { get; set; }

        [JsonProperty("ref_id")]
        public string refId { get; set; }

        [JsonProperty("ref_title")]
        public string refTitle { get; set; }

        [JsonProperty("ref_type")]
        public string refType { get; set; }
    }
}