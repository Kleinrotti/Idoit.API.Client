namespace Idoit.API.Client.CMDB.Category
{
    /// <summary>
    /// Provides methods for MultiValue category objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class IdoitMvcInstance<T> : IdoitCategoryInstance<T>, IDeletable, IArchiveable, IRecycable where T : IMultiValueResponse, new()
    {
        /// <summary>
        /// Initializes a new instance of the IdoitMvcInstance class.
        /// </summary>
        /// <param name="myClient"></param>
        public IdoitMvcInstance(IdoitClient myClient) : base(myClient)
        {
            Object = new T();
            Category = Object.category_id;
        }

        /// <summary>
        /// Deletes a category object. Property ObjectId and CateId has to be set.<br></br>
        /// Only category entries marked as archived, can be marked as deleted.<br></br>
        /// </summary>
        public void Delete()
        {
            parameter = Client.Parameters;
            parameter.Add("objID", ObjectId);
            parameter.Add("cateID", CateId);
            parameter.Add("category", Category);
            var result = Execute<IdoitResponse>("cmdb.category.delete");
            if (!result.success)
                throw new IdoitBadResponseException(result.message);
        }

        /// <summary>
        /// Recycle a category object. Property ObjectId and CateId has to be set. <br></br>
        /// Only category entries marked as archived or deleted can be recycled.
        /// </summary>
        public void Recycle()
        {
            parameter = Client.Parameters;
            parameter.Add("object", ObjectId);
            parameter.Add("category", Category);
            parameter.Add("entry", CateId);
            var response = Execute<IdoitResponse>("cmdb.category.recycle");
            if (!response.success)
                throw new IdoitBadResponseException(response.message);
        }

        /// <summary>
        /// Archive a category object. Property ObjectId and CateId has to be set. <br></br>
        /// Only category entries marked as normal can be marked as archived.
        /// </summary>
        public void Archive()
        {
            parameter = Client.Parameters;
            parameter.Add("object", ObjectId);
            parameter.Add("category", Category);
            parameter.Add("entry", CateId);
            var response = Execute<IdoitResponse>("cmdb.category.archive");
            if (!response.success)
                throw new IdoitBadResponseException(response.message);
        }
    }
}