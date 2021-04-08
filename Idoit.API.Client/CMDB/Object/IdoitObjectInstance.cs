using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Object
{
    /// <summary>
    /// Represents an IdoitObject which can be created, updated, read and archived.
    /// </summary>
    public class IdoitObjectInstance : IdoitApiBase
    {
        /// <summary>
        /// Type of the object, defined in IdoitObjectTypes.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Title of the object
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Type of the object, defined in IdoitCategory.
        /// </summary>

        //public string Category { get; set; }

        public string Purpose { get; set; }

        /// <summary>
        /// Type of the object, defined in IdoitCmdbStatus. Optional when creating a new object.
        /// </summary>
        public string CmdbStatus { get; set; }

        /// <summary>
        /// Description of the object. Optional when creating a new object.
        /// </summary>
        public string Description { get; set; }

        private IdoitObjectResult response;

        public IdoitObjectInstance(IdoitClient myClient) : base(myClient)
        {
        }

        /// <summary>
        /// Create a new object
        /// </summary>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <returns>The id of the created object</returns>
        public int Create(string type, string title)
        {
            Title = title;
            Type = type;
            Task t = Task.Run(() => { Creating().Wait(); }); t.Wait();
            return Id;
        }

        private async Task Creating()
        {
            parameter = Client.Parameters;
            parameter.Add("type", Type);
            parameter.Add("title", Title);
            parameter.Add("purpose", Purpose);
            parameter.Add("cmdb_status", CmdbStatus);
            parameter.Add("description", Description);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.create", parameter);
            Id = response.id;
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Update the title of an object
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="title"></param>
        public void Update(int objectId, string title)
        {
            Title = title;
            Task t = Task.Run(() => { Updating(objectId).Wait(); }); t.Wait();
        }

        private async Task Updating(int objectId)
        {
            parameter = Client.Parameters;
            parameter.Add("id", objectId);
            parameter.Add("title", Title);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.update", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Delete the given object
        /// </summary>
        /// <param name="objectId"></param>
        public void Delete(int objectId)
        {
            Task t = Task.Run(() => { Deleting(objectId).Wait(); }); t.Wait();
        }

        private async Task Deleting(int objectId)
        {
            parameter = Client.Parameters;
            parameter.Add("id", objectId);
            parameter.Add("status", "C__RECORD_STATUS__DELETED");
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.delete", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Purge the given object. This will remove it completely from the database.
        /// </summary>
        /// <param name="objectId"></param>
        public void Purge(int objectId)
        {
            Task t = Task.Run(() => { Purging(objectId).Wait(); }); t.Wait();
        }

        private async Task Purging(int objectId)
        {
            //The return Values as Object from diffrence Classes
            parameter = Client.Parameters;
            parameter.Add("id", objectId);
            parameter.Add("status", "C__RECORD_STATUS__PURGE");
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.delete", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Archive the given object
        /// </summary>
        /// <param name="objectId"></param>
        public void Archive(int objectId)
        {
            Task t = Task.Run(() => { Archiving(objectId).Wait(); }); t.Wait();
        }

        private async Task Archiving(int objectId)
        {
            parameter = Client.Parameters;
            parameter.Add("id", objectId);
            parameter.Add("status", "C__RECORD_STATUS__ARCHIVED");
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.delete", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Read the given object
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns>An <see cref="IdoitObjectResult"/></returns>
        public IdoitObjectResult Read(int objectId)
        {
            Task t = Task.Run(() => { Reading(objectId).Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading(int objectId)
        {
            parameter = Client.Parameters;
            parameter.Add("id", objectId);
            response = await Client.GetConnection().InvokeAsync<IdoitObjectResult>("cmdb.object.read", parameter);
        }
    }
}