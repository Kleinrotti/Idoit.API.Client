using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Dialog.Response
{
    public class DialogResult
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("Const")]
        public string Const { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}