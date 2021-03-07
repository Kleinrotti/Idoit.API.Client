using Idoit.API.Client.ApiException;
using Idoit.API.Client.CMDB.Object.Response;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Object
{
    /// <summary>
    /// Represents an IdoitObject which can be created, updated, read and archived.
    /// </summary>
    public class IdoitObjectInstance : IdoitApiBase
    {
        public int Id { get; set; }

        /// <summary>
        /// Type of the object, defined in IdoitObjectTypes.
        /// </summary>
        public string Type { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// Type of the object, defined in IdoitCategory.
        /// </summary>
        public string Category { get; set; }

        public string Purpose { get; set; }

        /// <summary>
        /// Type of the object, defined in IdoitCmdbStatus.
        /// </summary>
        public string CmdbStatus { get; set; }

        public string Description { get; set; }
        private IdoitObjectResult response;

        public IdoitObjectInstance(IdoitClient myClient) : base(myClient)
        {
        }

        //Create
        public int Create()
        {
            if (Type == null)
            {
                throw new IdoitAPIClientBadResponseException("Type is missing");
            }
            else if (Title == null)
            {
                throw new IdoitAPIClientBadResponseException("Title is missing");
            }
            Task t = Task.Run(() => { Creating().Wait(); }); t.Wait();
            return Id;
        }

        private async Task Creating()
        {
            parameter = client.GetParameter();
            parameter.Add("type", Type);
            parameter.Add("title", Title);
            parameter.Add("purpose", Purpose);
            parameter.Add("cmdb_status", CmdbStatus);
            parameter.Add("description", Description);
            parameter.Add("category", Category);
            var response = await client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.create", parameter);
            Id = response.id;
            if (response.success == false)
            {
                throw new IdoitAPIClientBadResponseException(response.message);
            }
        }

        //Update
        public void Update(int objectId)
        {
            if (Title == null)
            {
                throw new IdoitAPIClientBadResponseException("Title is missing");
            }
            Task t = Task.Run(() => { Updating(objectId).Wait(); }); t.Wait();
        }

        private async Task Updating(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            parameter.Add("title", Title);
            var response = await client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.update", parameter);
            if (response.success == false)
            {
                throw new IdoitAPIClientBadResponseException(response.message);
            }
        }

        //Delete
        public void Delete(int objectId)
        {
            Task t = Task.Run(() => { Deleting(objectId).Wait(); }); t.Wait();
        }

        private async Task Deleting(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            parameter.Add("status", "C__RECORD_STATUS__DELETED");
            var response = await client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.delete", parameter);
            if (response.success == false)
            {
                throw new IdoitAPIClientBadResponseException(response.message);
            }
        }

        //purge
        public void Purge(int objectId)
        {
            Task t = Task.Run(() => { Purging(objectId).Wait(); }); t.Wait();
        }

        private async Task Purging(int objectId)
        {
            //The return Values as Object from diffrence Classes
            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            parameter.Add("status", "C__RECORD_STATUS__PURGE");
            var response = await client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.delete", parameter);
            if (response.success == false)
            {
                throw new IdoitAPIClientBadResponseException(response.message);
            }
        }

        //archive
        public void Archive(int objectId)
        {
            Task t = Task.Run(() => { Archiving(objectId).Wait(); }); t.Wait();
        }

        private async Task Archiving(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            parameter.Add("status", "C__RECORD_STATUS__ARCHIVED");
            var response = await client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.delete", parameter);
            if (response.success == false)
            {
                throw new IdoitAPIClientBadResponseException(response.message);
            }
        }

        //Read
        public IdoitObjectResult Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading(int objectId)
        {
            parameter = client.GetParameter();
            parameter.Add("id", objectId);
            response = await client.GetConnection().InvokeAsync<IdoitObjectResult>("cmdb.object.read", parameter);
        }
    }
}