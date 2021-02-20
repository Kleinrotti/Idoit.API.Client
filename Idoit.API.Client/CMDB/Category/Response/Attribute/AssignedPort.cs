using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class AssignedPort : IdoitAttribute
    {
        [JsonProperty("reference")]
        public string reference { get; set; }
    }
}