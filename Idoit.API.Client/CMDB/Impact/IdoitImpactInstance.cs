using Idoit.API.Client.Contants;

namespace Idoit.API.Client.CMDB.Impact
{
    public class IdoitImpactInstance : IdoitInstanceBase, IReadable<object>
    {
        public int ObjectId { get; set; }
        public int RelationType { get; set; }
        public IdoitStatusTypes? Status { get; set; }

        public IdoitImpactInstance(IClient myClient) : base(myClient)
        {
        }

        /// <summary>
        /// Perform an impact analysis for a specific object by its relation type identifier.
        /// </summary>
        /// <returns></returns>
        public object Read()
        {
            parameter = Client.Parameters;
            parameter.Add("id", ObjectId);
            parameter.Add("relation_type", RelationType);
            parameter.Add("status", Status);
            return Execute<object>("cmdb.impact.read");
        }
    }
}