using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class Address : IdoitAttribute
    {
        [JsonProperty("hostname")]
        public string hostName { get; set; }
    }
}