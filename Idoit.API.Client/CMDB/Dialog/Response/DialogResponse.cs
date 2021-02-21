using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Dialog.Response
{
    public class DialogResponse
    {
        [JsonProperty("entry_id")]
        public int entryId { get; set; }

        [JsonProperty("success")]
        public string success { get; set; }
    }
}