namespace Idoit.API.Client.CMDB.Reports
{
    public class IdoitReportsResponse
    {
        public int id { get; internal set; }
        public string category { get; internal set; }
        public string title { get; internal set; }
        public string description { get; internal set; }
        public string created { get; internal set; }
    }
}