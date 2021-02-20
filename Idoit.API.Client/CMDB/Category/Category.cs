using Idoit.API.Client.ApiException;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public abstract class Category
    {
        public string category;
        public int id;
        public IdoitClient client;
        private Dictionary<string, object> parameter;

        public Category(IdoitClient myClient)
        {
            client = myClient;
        }

        //Create
        public int Create(int objectId, IRequest request)
        {
            Task t = Task.Run(() => { Creating(request, objectId).Wait(); }); t.Wait();
            return id;
        }

        private async Task Creating(IRequest request, int objectId)
        {
            object data = client.GetData(request);
            if (data == null)
            {
                throw new Exception("Data is missing");
            }
            parameter = client.GetParameter();
            parameter.Add("data", data);
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            Response response = await client.GetConnection().InvokeAsync<Response>
            ("cmdb.category.create", parameter);
            id = response.id;
            if (response.success == false)
            {
                throw new IdoitAPIClientBadResponseException(response.message);
            }
        }

        //Update
        public void Update(int objectId, IRequest request)
        {
            Task t = Task.Run(() => { Updating(objectId, request).Wait(); }); t.Wait();
        }

        private async Task Updating(int objectId, IRequest request)
        {
            object data = client.GetData(request);

            if (data == null)
            {
                throw new Exception("Data is missing");
            }
            parameter = client.GetParameter();
            parameter.Add("data", data);
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            Response response = await client.GetConnection().InvokeAsync<Response>
                    ("cmdb.category.update", parameter);
            if (response.success == false)
            {
                throw new IdoitAPIClientBadResponseException(response.message);
            }
        }

        //Quickpurge
        public void Quickpurge(int objectId, int entryID)
        {
            if (entryID == 0)
            {
                throw new Exception("EntryID is missing");
            }
            Task t = Task.Run(() => { QuickPurging(objectId, entryID).Wait(); }); t.Wait();
        }

        private async Task QuickPurging(int objectId, int entryID)
        {
            parameter = client.GetParameter();
            parameter.Add("cateID", entryID);
            parameter.Add("objID", objectId);
            parameter.Add("category", category);
            Response result = await client.GetConnection().InvokeAsync<Response>
            ("cmdb.category.quickpurge", parameter);
            if (result.success == false)
            {
                throw new IdoitAPIClientBadResponseException(result.message);
            }
        }
    }
}