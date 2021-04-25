using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Idoit.API.Client.CMDB.Logbook
{
    public class IdoitLogbookResponse
    {
        public int logbook_id { get; set; }
        public int logbook_catg_id { get; set; }
        public string description { get; set; }
        public IDictionary<string, LogbookChanges> changes { get; set; }
        public DateTime date { get; set; }
        public string username { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        public int object_id { get; set; }
        public string object_title { get; set; }
        public string object_title_static { get; set; }
        public string source { get; set; }
        public string source_constant { get; set; }
        public int level_id { get; set; }
    }
}