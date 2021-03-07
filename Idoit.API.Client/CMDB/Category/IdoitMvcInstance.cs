using Idoit.API.Client.ApiException;
using System;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    public class IdoitMvcInstance<T> : IdoitCategory<T> where T : IMultiValueResponse, new()
    {
        public IdoitMvcInstance(IdoitClient myClient) : base(myClient)
        {
            Object = new T();
            CategoryId = Object.category_id;
        }

        //Update
        new public void Update(int objectId, IRequest request)
        {
            if (request.category_id == 0)
            {
                throw new Exception("CateId is missing");
            }
            base.Update(objectId, request);
        }

        //Delete
        public void Delete(int objectId, int entryID)
        {
            if (entryID == 0)
            {
                throw new Exception("EntryID is missing");
            }
            Task t = Task.Run(() => { Deleting(objectId, entryID).Wait(); }); t.Wait();
        }

        private async Task Deleting(int objectId, int entryID)
        {
            //The return Values as Object from diffrence Classes
            parameter = Client.GetParameter();
            parameter.Add("objID", objectId);
            parameter.Add("cateID", entryID);
            parameter.Add("category", CategoryId);
            var result = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.category.delete", parameter);
            if (result.success == false)
            {
                throw new IdoitAPIClientBadResponseException(result.message);
            }
        }
    }
}