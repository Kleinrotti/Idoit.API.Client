using Idoit.API.Client.ApiException;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public abstract class IdoitCategory<T>
    {
        public string CategoryId { get; protected set; }
        public int Id { get; protected set; }
        public IdoitClient Client { get; }
        protected Dictionary<string, object> parameter;
        protected List<T[]> response;
        public T Object { get; protected set; }

        public IdoitCategory(IdoitClient myClient)
        {
            Client = myClient;
        }

        //Read
        public List<T[]> Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading(int objectId)
        {
            parameter = Client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("category", CategoryId);
            response = new List<T[]>();
            response.Add(await Client.GetConnection().InvokeAsync<T[]>
            ("cmdb.category.read", parameter));
        }

        //Create
        public int Create(int objectId, IRequest request)
        {
            Task t = Task.Run(() => { Creating(request, objectId).Wait(); }); t.Wait();
            return Id;
        }

        private async Task Creating(IRequest request, int objectId)
        {
            object data = Client.GetData(request);
            if (data == null)
            {
                throw new Exception("Data is missing");
            }
            parameter = Client.GetParameter();
            parameter.Add("data", data);
            parameter.Add("objID", objectId);
            parameter.Add("category", CategoryId);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.category.create", parameter);
            Id = response.id;
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
            object data = Client.GetData(request);

            if (data == null)
            {
                throw new Exception("Data is missing");
            }
            parameter = Client.GetParameter();
            parameter.Add("data", data);
            parameter.Add("objID", objectId);
            parameter.Add("category", CategoryId);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
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
            parameter = Client.GetParameter();
            parameter.Add("cateID", entryID);
            parameter.Add("objID", objectId);
            parameter.Add("category", CategoryId);
            var result = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.category.quickpurge", parameter);
            if (result.success == false)
            {
                throw new IdoitAPIClientBadResponseException(result.message);
            }
        }
    }
}