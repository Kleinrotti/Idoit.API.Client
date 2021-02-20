using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class DialogPlus
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("const")]
        public string Const { get; set; }

        [JsonProperty("title_lang")]
        public string titleLang { get; set; }
    }
}