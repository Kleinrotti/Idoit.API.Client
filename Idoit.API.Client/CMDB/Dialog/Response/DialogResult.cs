using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Dialog
{
    public sealed class DialogResult
    {
        [JsonProperty("id")]
        public string id { get; internal set; }

        [JsonProperty("Const")]
        public string Const { get; internal set; }

        [JsonProperty("title")]
        public string title { get; internal set; }
    }
}