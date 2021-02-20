
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class AccessResponse : IMultiValueResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("objID")]
        public string objID { get; set; }

        [JsonProperty("primary_url")]
        public string primaryUrl { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("type")]
        public DialogPlus type { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("formatted_url")]
        public string formattedUrl { get; set; }

        [JsonProperty("primary")]
        public Primary primary { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        public string category_id { get; } = "C__CATG__ACCESS";
    }
}