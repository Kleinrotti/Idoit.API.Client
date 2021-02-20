using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class Contact : IdoitAttribute
    {
        [JsonProperty("ldap_group")]
        public string ldapGroup { get; set; }

        [JsonProperty("email_address")]
        public string emailAddress { get; set; }

        [JsonProperty("phone")]
        public string phone { get; set; }

        [JsonProperty("right_group")]
        public string rightGroup { get; set; }

        [JsonProperty("sysid")]
        public string sysId { get; set; }
    }
}