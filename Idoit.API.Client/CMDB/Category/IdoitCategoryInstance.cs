namespace Idoit.API.Client.CMDB.Category
{
    public abstract class IdoitCategoryInstance<T> : IdoitInstanceBase, IReadable<T[]>, IUpdatable, IPurgeable
    {
        public int? ObjectId { get; set; }
        public IRequest ObjectRequest { get; set; }
        public int? CateId { get; set; }

        public T Object { get; protected set; }

        public IdoitCategoryInstance(IdoitClient myClient) : base(myClient)
        {
        }

        /// <summary>
        /// Reads the given object. Property ObjectId has to be set.
        /// </summary>
        /// <returns>A list of that generic data type</returns>
        public virtual T[] Read()
        {
            parameter = Client.Parameters;
            parameter.Add("objID", ObjectId);
            parameter.Add("category", Category);
            return Execute<T[]>("cmdb.category.read");
        }

        /// <summary>
        /// Create the given object. Property ObjectId and ObjectRequest has to be set.
        /// </summary>
        /// <returns>The id of that newly created object.</returns>
        public virtual int Create()
        {
            parameter = Client.Parameters;
            parameter.Add("data", ObjectRequest.GetObject());
            parameter.Add("objID", ObjectId);
            parameter.Add("category", Category);
            var response = Execute<IdoitResponse>("cmdb.category.create");
            Id = response.id;
            if (!response.success)
                throw new IdoitBadResponseException(response.message);
            return Id;
        }

        /// <summary>
        /// Updates the given object. Property ObjectId and RequestObject has to be set.
        /// </summary>
        public virtual void Update()
        {
            parameter = Client.Parameters;
            parameter.Add("data", ObjectRequest.GetObject());
            parameter.Add("objID", ObjectId);
            parameter.Add("category", Category);
            var response = Execute<IdoitResponse>("cmdb.category.update");
            if (!response.success)
                throw new IdoitBadResponseException(response.message);
        }

        /// <summary>
        /// QuickPurge the given object entry. Property ObjectId and CateId has to be set.
        /// </summary>
        public virtual void QuickPurge()
        {
            parameter = Client.Parameters;
            parameter.Add("cateID", CateId);
            parameter.Add("objID", ObjectId);
            parameter.Add("category", Category);
            var result = Execute<IdoitResponse>("cmdb.category.quickpurge");
            if (!result.success)
                throw new IdoitBadResponseException(result.message);
        }

        /// <summary>
        /// Purge the given object entry. Property ObjectId and CateId has to be set.
        /// </summary>
        public virtual void Purge()
        {
            parameter = Client.Parameters;
            parameter.Add("object", ObjectId);
            parameter.Add("category", Category);
            parameter.Add("entry", CateId);
            var result = Execute<IdoitResponse>("cmdb.category.purge");
            if (!result.success)
                throw new IdoitBadResponseException(result.message);
        }
    }
}