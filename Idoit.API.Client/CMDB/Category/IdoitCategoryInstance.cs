using System;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public abstract class IdoitCategoryInstance<T> : IdoitInstanceBase, IReadable<T[]>, IUpdatable, IPurgeable
    {
        protected T[] response;

        /// <summary>
        /// Returns the current <see cref="T"/> object
        /// </summary>
        public T Object { get; protected set; }

        public int? ObjectId { get; set; }
        public IRequest ObjectRequest { get; set; }
        public int? EntryId { get; set; }

        public IdoitCategoryInstance(IdoitClient myClient) : base(myClient)
        {
            Client = myClient;
        }

        /// <summary>
        /// Reads the given object. Property ObjectId has to be set.
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns>A list of that generic data type</returns>
        public virtual T[] Read()
        {
            if (ObjectId == null)
                throw new ArgumentException("Property was not set.");
            Task t = Task.Run(() => { Reading().Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading()
        {
            parameter = Client.Parameters;
            parameter.Add("objID", ObjectId);
            parameter.Add("category", Category);
            response = await Client.GetConnection().InvokeAsync<T[]>
            ("cmdb.category.read", parameter);
        }

        /// <summary>
        /// Create the given object. Property ObjectId and RequestObject has to be set.
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="request"></param>
        /// <returns>An id of that newly created mvc object</returns>
        public virtual int Create()
        {
            if (ObjectId == null || ObjectRequest == null)
                throw new ArgumentException("Property was not set.");
            Task t = Task.Run(() => { Creating().Wait(); }); t.Wait();
            return Id;
        }

        private async Task Creating()
        {
            parameter = Client.Parameters;
            parameter.Add("data", ObjectRequest.GetObject());
            parameter.Add("objID", ObjectId);
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
        /// Updates the given object. Property ObjectId and RequestObject has to be set.
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="request"></param>
        public virtual void Update()
        {
            if (ObjectId == null || ObjectRequest == null)
                throw new ArgumentException("Property was not set.");
            Task t = Task.Run(() => { Updating().Wait(); }); t.Wait();
        }

        private async Task Updating()
        {
            parameter = Client.Parameters;
            parameter.Add("data", ObjectRequest.GetObject());
            parameter.Add("objID", ObjectId);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
                    ("cmdb.category.update", parameter);
            if (response.success == false)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Purge the given object entry. Property ObjectId and EntryId has to be set.
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="entryID"></param>
        public virtual void Purge()
        {
            if (EntryId == null || ObjectId == null)
            {
                throw new ArgumentException("Property was not set.");
            }
            Task t = Task.Run(() => { QuickPurging().Wait(); }); t.Wait();
        }

        private async Task QuickPurging()
        {
            parameter = Client.Parameters;
            parameter.Add("cateID", EntryId);
            parameter.Add("objID", ObjectId);
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