using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class MemoryResponse : IMultiValueResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("objID")]
        public string objID { get; set; }

        [JsonProperty("quantity")]
        public string quantity { get; set; }

        public DialogPlus title { get; set; }
        public DialogPlus manufacturer { get; set; }
        public DialogPlus type { get; set; }

        [JsonProperty("total_capacity")]
        public string totalCapacity { get; set; }

        public Title capacity { get; set; }
        public DialogPlus unit { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        public string category_id { get; } = "C__CATG__MEMORY";
    }
}