using Idoit.API.Client.ApiException;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public class MultiValueCategory<T> : Category where T : IMultiValueResponse, new()
    {
        private Dictionary<string, object> parameter;
        private List<T[]> cpuResponse;
        public T Object { get; }

        public MultiValueCategory(IdoitClient myClient) : base(myClient)
        {
            Object = new T();
            category = Object.category_id;
        }

        //Read
        public List<T[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return cpuResponse;
        }

        private async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            cpuResponse = new List<T[]>();
            cpuResponse.Add(await client.GetConnection().InvokeAsync<T[]>
            ("cmdb.category.read", parameter));
        }

        //Update
        new public void Update(int objectId, IRequest request)
        {
            if (request.category_id == 0)
            {
                throw new Exception("CateId is missing");
            }
            base.Update(objectId, request);
        }

        //Delete
        public void Delete(int objectId, int entryID)
        {
            if (entryID == 0)
            {
                throw new Exception("EntryID is missing");
            }
            Task t = Task.Run(() => { Deleting(objectId, entryID).Wait(); }); t.Wait();
        }

        private async Task Deleting(int objectId, int entryID)
        {
            //The return Values as Object from diffrence Classes
            parameter = client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("cateID", entryID);
            parameter.Add("category", category);
            Response result = await client.GetConnection().InvokeAsync<Response>
            ("cmdb.category.delete", parameter);
            if (result.success == false)
            {
                throw new IdoitAPIClientBadResponseException(result.message);
            }
        }
    }
}