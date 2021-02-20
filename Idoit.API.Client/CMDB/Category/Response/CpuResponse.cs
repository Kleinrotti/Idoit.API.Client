
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class CpuResponse : IMultiValueResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("objID")]
        public string objID { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        public DialogPlus manufacturer { get; set; }
        public DialogPlus type { get; set; }

        //public Unit frequency { get; set; }
        public DialogPlus frequency_unit { get; set; }

        [JsonProperty("cores")]
        public string cores { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        public string category_id { get; } = "C__CATG__CPU";
    }
}