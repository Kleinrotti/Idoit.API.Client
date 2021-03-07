using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Objects
{
    public class IdoitObjectsInstance : IdoitApiBase
    {
        public IdoitObjectsInstance(IdoitClient myClient) : base(myClient)
        {
            client = myClient;
        }

        private List<IdoitObjectsResult[]> response;
        public int id;
        public string type, title, category, purpose, cmdbStatus, description;//Create

        //Read Objects
        public string limit, orderBy, sort; //ReadObjects

        public List<IdoitObjectsResult[]> Read(IdoitFilter filter)
        {
            Task t = Task.Run(() => { Reading(filter).Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading(IdoitFilter filter)
        {
            object data = client.GetData(filter);
            parameter = client.GetParameter();
            parameter.Add("filter", data);
            parameter.Add("sort", sort);
            parameter.Add("limit", limit);
            parameter.Add("order_by", orderBy);
            response = new List<IdoitObjectsResult[]>();
            response.Add(await client.GetConnection().InvokeAsync<IdoitObjectsResult[]>("cmdb.objects.read", parameter));
        }
    }
}