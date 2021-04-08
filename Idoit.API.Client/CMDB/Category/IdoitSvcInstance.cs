namespace Idoit.API.Client.CMDB.Category
{
    /// <summary>
    /// Initializes a new instance of the IdoitSvcInstance class. Manage idoit SingleValue items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class IdoitSvcInstance<T> : IdoitCategory<T> where T : ISingleValueResponse, new()
    {
        public IdoitSvcInstance(IdoitClient myClient) : base(myClient)
        {
            Object = new T();
            Category = Object.category_id;
        }
    }
}