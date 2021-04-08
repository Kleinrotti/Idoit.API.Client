using System;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    /// <summary>
    /// Represents a class for Idoit MultiValue items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class IdoitMvcInstance<T> : IdoitCategory<T> where T : IMultiValueResponse, new()
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

        public override void Update(int objectId, IRequest request)
        {
            if (request.category_id == 0)
            {
                throw new ArgumentException("CateId is missing");
            }
            base.Update(objectId, request);
        }

        /// <summary>
        /// Deletes the given object.
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="entryID"></param>
        public void Delete(int objectId, int entryID)
        {
            Task t = Task.Run(() => { Deleting(objectId, entryID).Wait(); }); t.Wait();
        }

        private async Task Deleting(int objectId, int entryID)
        {
            //The return Values as Object from diffrence Classes
            parameter = Client.Parameters;
            parameter.Add("objID", objectId);
            parameter.Add("cateID", entryID);
            parameter.Add("category", Category);
            var result = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.category.delete", parameter);
            if (!result.success)
            {
                throw new IdoitBadResponseException(result.message);
            }
        }
    }
}