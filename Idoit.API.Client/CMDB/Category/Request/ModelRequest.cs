namespace Idoit.API.Client.CMDB.Category
{
    public class ModelRequest : IRequest
    {
        public int? category_id { get; set; }
        public int manufacturer { get; set; }
        public string title { get; set; }
        public string productid { get; set; }
        public string service_tag { get; set; }
        public string serial { get; set; }
        public string firmware { get; set; }
        public string description { get; set; }
    }
}