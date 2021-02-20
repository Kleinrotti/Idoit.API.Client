using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class SearchDomain
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}