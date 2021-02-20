using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class Interface : IdoitAttribute
    {
        [JsonProperty("serial")]
        public string serial { get; set; }

        [JsonProperty("slot")]
        public string slot { get; set; }

        [JsonProperty("manufacturer")]
        public string manufacturer { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }
    }
}