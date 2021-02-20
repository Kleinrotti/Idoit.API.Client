
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class ContactAssignmentResponse : IMultiValueResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("objID")]
        public string objID { get; set; }

        [JsonProperty("contact")]
        public Contact contact { get; set; }

        [JsonProperty("primary_contact")]
        public string primaryContact { get; set; }

        [JsonProperty("contact_object")]
        public ContactObject contactObject { get; set; }

        [JsonProperty("primary")]
        public Primary primary { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("contact_list")]
        public string contactList { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        public string category_id { get; } = "C__CATG__CONTACT";
    }
}