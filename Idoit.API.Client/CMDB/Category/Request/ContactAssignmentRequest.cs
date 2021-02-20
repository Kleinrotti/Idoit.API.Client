namespace Idoit.API.Client.CMDB.Category
{
    public class ContactAssignmentRequest : IRequest
    {
        public int category_id { get; set; }// This Attribut is jsut for the Multivalue Category
        public string contact { get; set; }
        public string primary_contact { get; set; }
        public string contact_object { get; set; }
        public string primary { get; set; }
        public string role { get; set; }
        public string contact_list { get; set; }
        public string description { get; set; }
    }
}