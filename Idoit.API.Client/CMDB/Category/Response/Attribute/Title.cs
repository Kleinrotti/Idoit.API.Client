using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class Title
    {
        [JsonProperty("title")]
        public string title { get; set; }
    }
}