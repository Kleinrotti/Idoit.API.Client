using System;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public abstract class IdoitCategory<T> : IdoitApiBase
    {
        protected T[] response;

        /// <summary>
        /// Returns the current <see cref="T"/> object
        /// </summary>
        public T Object { get; protected set; }

        public IdoitCategory(IdoitClient myClient) : base(myClient)
        {
            Client = myClient;
        }

        /// <summary>
        /// Reads the given object
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns>A list of that generic data type</returns>
        public virtual T[] Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading(int objectId)
        {
            parameter = Client.Parameters;
            parameter.Add("objID", objectId);
            parameter.Add("category", Category);
            response = await Client.GetConnection().InvokeAsync<T[]>
            ("cmdb.category.read", parameter);
        }

        /// <summary>
        /// Create the given object
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="request"></param>
        /// <returns>An id of that newly created object</returns>
        public virtual int Create(int objectId, IRequest request)
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
            parameter = Client.Parameters;
            parameter.Add("data", data);
            parameter.Add("objID", objectId);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.category.create", parameter);
            Id = response.id;
            if (response.success == false)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Updates the given object
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="request"></param>
        public virtual void Update(int objectId, IRequest request)
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
            parameter = Client.Parameters;
            parameter.Add("data", data);
            parameter.Add("objID", objectId);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
                    ("cmdb.category.update", parameter);
            if (response.success == false)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Purge the given object entry
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="entryID"></param>
        public virtual void Quickpurge(int objectId, int entryID)
        {
            if (entryID == 0)
            {
                throw new ArgumentException("EntryID is missing");
            }
            Task t = Task.Run(() => { QuickPurging(objectId, entryID).Wait(); }); t.Wait();
        }

        private async Task QuickPurging(int objectId, int entryID)
        {
            parameter = Client.Parameters;
            parameter.Add("cateID", entryID);
            parameter.Add("objID", objectId);
            parameter.Add("category", Category);
            var result = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.category.quickpurge", parameter);
            if (result.success == false)
            {
                throw new IdoitBadResponseException(result.message);
            }
        }
    }
}