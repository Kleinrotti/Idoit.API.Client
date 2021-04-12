using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Dialog
{
    public sealed class DialogResponse
    {
        [JsonProperty("entry_id")]
        public int entryId { get; set; }

        [JsonProperty("success")]
        public bool success { get; set; }
    }
}