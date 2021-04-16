using Idoit.API.Client.Contants;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Object
{
    /// <summary>
    /// Represents an IdoitObject which can be created, updated, read and archived.
    /// </summary>
    public class IdoitObjectInstance : IdoitInstanceBase, IReadable<IdoitObjectResult>, ICreatable, IUpdatable, IDeletable, IPurgeable, IArchiveable
    {
        /// <summary>
        /// Type of the object, defined in IdoitObjectTypes.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Type of the object, defined in IdoitCategory.
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// Type of the object. Optional when creating a new object.
        /// </summary>
        public IdoitCmdbStatus CmdbStatus { get; set; }

        /// <summary>
        /// Description of the object. Optional when creating a new object.
        /// </summary>
        public string Description { get; set; }

        public int ObjectId { get; set; }

        private IdoitObjectResult response;

        public IdoitObjectInstance(IdoitClient myClient) : base(myClient)
        {
        }

        /// <summary>
        /// Create a new object. Property Type and Value has to be set.
        /// </summary>
        /// <returns>The id of the created object</returns>
        public int Create()
        {
            Task t = Task.Run(() => { Creating().Wait(); }); t.Wait();
            return Id;
        }

        private async Task Creating()
        {
            parameter = Client.Parameters;
            parameter.Add("type", Type);
            parameter.Add("title", Value);
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
        /// Update the title of an object. Property ObjectId and Value has to be set.
        /// </summary>
        public void Update()
        {
            Task t = Task.Run(() => { Updating().Wait(); }); t.Wait();
        }

        private async Task Updating()
        {
            parameter = Client.Parameters;
            parameter.Add("id", ObjectId);
            parameter.Add("title", Value);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.update", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Delete the given object. Property ObjectId has to be set.
        /// </summary>
        public void Delete()
        {
            Task t = Task.Run(() => { Deleting().Wait(); }); t.Wait();
        }

        private async Task Deleting()
        {
            parameter = Client.Parameters;
            parameter.Add("id", ObjectId);
            parameter.Add("status", "C__RECORD_STATUS__DELETED");
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.delete", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Purge the given object. This will remove it completely from the database. Property ObjectId has to be set.
        /// </summary>
        public void Purge()
        {
            Task t = Task.Run(() => { Purging().Wait(); }); t.Wait();
        }

        private async Task Purging()
        {
            //The return Values as Object from diffrence Classes
            parameter = Client.Parameters;
            parameter.Add("id", ObjectId);
            parameter.Add("status", "C__RECORD_STATUS__PURGE");
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.object.delete", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Archive the given object. Property ObjectId has to be set.
        /// </summary>
        public void Archive()
        {
            Task t = Task.Run(() => { Archiving().Wait(); }); t.Wait();
        }

        private async Task Archiving()
        {
            parameter = Client.Parameters;
            parameter.Add("id", ObjectId);
            parameter.Add("status", "C__RECORD_STATUS__ARCHIVED");
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
                ("cmdb.object.delete", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Read the given object. Property ObjectId has to be set.
        /// </summary>
        /// <returns>An <see cref="IdoitObjectResult"/></returns>
        public IdoitObjectResult Read()
        {
            Task t = Task.Run(() => { Reading().Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading()
        {
            parameter = Client.Parameters;
            parameter.Add("id", ObjectId);
            response = await Client.GetConnection().InvokeAsync<IdoitObjectResult>("cmdb.object.read", parameter);
        }

        /// <summary>
        /// Set object state as template. Property ObjectId has to be set.
        /// </summary>
        public void MarkAsTemplate()
        {
            Task t = Task.Run(() => { markAsTemplate().Wait(); }); t.Wait();
        }

        private async Task markAsTemplate()
        {
            parameter = Client.Parameters;
            parameter.Add("id", ObjectId);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
                ("cmdb.object.markAsTemplate", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }

        /// <summary>
        /// Set object state as mass change template. Property ObjectId has to be set.
        /// </summary>
        public void MarkAsMassChangeTemplate()
        {
            Task t = Task.Run(() => { markAsMassTemplate().Wait(); }); t.Wait();
        }

        private async Task markAsMassTemplate()
        {
            parameter = Client.Parameters;
            parameter.Add("id", ObjectId);
            var response = await Client.GetConnection().InvokeAsync<IdoitResponse>
                ("cmdb.object.markAsMassChangeTemplate", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.message);
            }
        }
    }
}