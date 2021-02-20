
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class ModelResponse : ISingleValueResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("objID")]
        public string objID { get; set; }

        [JsonProperty("title")]
        public DialogPlus title { get; set; }

        [JsonProperty("manufacturer")]
        public DialogPlus manufacturer { get; set; }

        [JsonProperty("productid")]
        public string productId { get; set; }

        [JsonProperty("service_tag")]
        public string serviceTag { get; set; }

        [JsonProperty("serial")]
        public string serial { get; set; }

        [JsonProperty("firmware")]
        public string firmware { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        public string category_id { get; }= "C__CATG__MODEL";
    }
}