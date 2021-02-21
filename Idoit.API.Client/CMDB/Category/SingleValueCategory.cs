namespace Idoit.API.Client.CMDB.Category
{
    public class SingleValueCategory<T> : Category<T> where T : ISingleValueResponse, new()
    {
        public SingleValueCategory(IdoitClient myClient) : base(myClient)
        {
            Object = new T();
            CategoryId = Object.category_id;
        }
    }
}