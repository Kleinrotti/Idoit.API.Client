namespace Idoit.API.Client.CMDB.Category
{
    public class IdoitSvcInstance<T> : IdoitCategory<T> where T : ISingleValueResponse, new()
    {
        public IdoitSvcInstance(IdoitClient myClient) : base(myClient)
        {
            Object = new T();
            CategoryId = Object.category_id;
        }
    }
}