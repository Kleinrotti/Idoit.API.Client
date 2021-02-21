using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public class SingleValueCategory<T> : Category where T : ISingleValueResponse, new()
    {
        private Dictionary<string, object> parameter;
        private List<T[]> response;
        public T Object { get; }

        public SingleValueCategory(IdoitClient myClient) : base(myClient)
        {
            Object = new T();
            category = Object.category_id;
        }

        //Read
        public List<T[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            response = new List<T[]>();
            response.Add(await client.GetConnection().InvokeAsync<T[]>
            ("cmdb.category.read", parameter));
        }
    }
}