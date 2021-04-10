namespace Idoit.API.Client.CMDB.Category
{
    public class AccessRequest : IRequest
    {
        public int? category_id { get; set; }
        public string primary_url { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string formatted_url { get; set; }
        public string primary { get; set; }
        public string description { get; set; }
    }
}