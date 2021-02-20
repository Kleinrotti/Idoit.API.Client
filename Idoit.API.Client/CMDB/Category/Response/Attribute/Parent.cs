using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class Parent : IdoitAttribute
    {
        [JsonProperty("sysid")]
        public string sysId { get; set; }

        [JsonProperty("type_title")]
        public string typeTitle { get; set; }

        [JsonProperty("location_path")]
        public string locationPath { get; set; }
    }
}