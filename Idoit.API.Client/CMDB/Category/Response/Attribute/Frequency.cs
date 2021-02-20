using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class Frequency : IdoitAttribute
    {
        [JsonProperty("sysid")]
        public string sysId { get; set; }
    }
}