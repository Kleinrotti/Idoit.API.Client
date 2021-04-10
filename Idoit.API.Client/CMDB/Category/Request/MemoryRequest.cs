namespace Idoit.API.Client.CMDB.Category
{
    public class MemoryRequest : IRequest
    {
        public int? category_id { get; set; }
        public int quantity { get; set; }
        public int title { get; set; }
        public int manufacturer { get; set; }
        public int type { get; set; }
        public float total_capacity { get; set; }
        public float capacity { get; set; }
        public int unit { get; set; }
        public string description { get; set; }
    }
}