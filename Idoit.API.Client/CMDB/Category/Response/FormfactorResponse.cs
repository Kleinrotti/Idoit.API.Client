
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category
{
    public class FormfactorResponse : ISingleValueResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("objID")]
        public string objID { get; set; }

        public DialogPlus formfactor { get; set; }

        [JsonProperty("rackunits")]
        public string rackUnits { get; set; }

        public DialogPlus unit { get; set; }
        public Title width { get; set; }
        public Title height { get; set; }
        public Title depth { get; set; }
        public Title weight { get; set; }
        public DialogPlus weight_unit { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        public string category_id { get; }= "C__CATG__FORMFACTOR";
    }
}