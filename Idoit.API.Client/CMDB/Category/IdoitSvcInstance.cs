namespace Idoit.API.Client.CMDB.Category
{
    /// <summary>
    /// Provides methods for SingleValue category objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class IdoitSvcInstance<T> : IdoitCategoryInstance<T> where T : ISingleValueResponse, new()
    {
        public IdoitSvcInstance(IdoitClient myClient) : base(myClient)
        {
            Object = new T();
            Category = Object.category_id;
        }
    }
}