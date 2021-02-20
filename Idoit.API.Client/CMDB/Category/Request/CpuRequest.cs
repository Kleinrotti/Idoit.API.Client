namespace Idoit.API.Client.CMDB.Category
{
    public class CpuRequest : IRequest
    {
        public int category_id { get; set; }// This Attribut is jsut for the Multi-value category
        public string title { get; set; }
        public int manufacturer { get; set; }
        public int type { get; set; }
        public double frequency { get; set; }
        public int frequencyUnit { get; set; }
        public int cores { get; set; }
        public string description { get; set; }
    }
}