using System;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Logbook
{
    public class IdoitLogbookInstance : IdoitInstanceBase, IReadable<IdoitLogbookResponse[]>, ICreatable
    {
        private IdoitLogbookResponse[] response;

        public int ObjectId { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

        public IdoitLogbookInstance(IClient myClient) : base(myClient)
        {
        }

        /// <summary>
        /// Read idoit logbook entries.
        /// </summary>
        /// <returns>An <see cref="IdoitLogbookResponse"/> array.</returns>
        public IdoitLogbookResponse[] Read()
        {
            Task t = Task.Run(async () =>
            {
                parameter = Client.Parameters;
                response = await Client.GetConnection().InvokeAsync<IdoitLogbookResponse[]>("cmdb.logbook.read", parameter);
            });
            t.Wait();
            return response;
        }

        /// <summary>
        /// Read idoit logbook entries.
        /// </summary>
        /// <param name="since">List only entries since a specific date.</param>
        /// <param name="limit">Limit number of entries.</param>
        /// <returns>An <see cref="IdoitLogbookResponse"/> array.</returns>
        public IdoitLogbookResponse[] Read(DateTime? since = null, int limit = 1000)
        {
            Task t = Task.Run(async () =>
            {
                parameter = Client.Parameters;
                parameter.Add("limit", limit);
                parameter.Add("since", since.ToString());
                response = await Client.GetConnection().InvokeAsync<IdoitLogbookResponse[]>("cmdb.logbook.read", parameter);
            });
            t.Wait();
            return response;
        }

        /// <summary>
        /// Read idoit logbook entries for a specific object.
        /// </summary>
        /// <param name="objectId">Object identifier.</param>
        /// <param name="since">List only entries since a specific date.</param>
        /// <param name="limit">Limit number of entries.</param>
        /// <returns>An <see cref="IdoitLogbookResponse"/> array.</returns>
        public IdoitLogbookResponse[] Read(int objectId, DateTime? since = null, int limit = 1000)
        {
            Task t = Task.Run(async () =>
            {
                parameter = Client.Parameters;
                parameter.Add("object_id", objectId);
                parameter.Add("limit", limit);
                parameter.Add("since", since.ToString());
                response = await Client.GetConnection().InvokeAsync<IdoitLogbookResponse[]>("cmdb.logbook.read", parameter);
            });
            t.Wait();
            return response;
        }

        /// <summary>
        /// Create an idoit logbook entry for a specific object. Property ObjectId and Message has to be set. Description is optional.
        /// </summary>
        /// <returns>The id of the created entry.</returns>
        public int Create()
        {
            Task t = Task.Run(async () =>
            {
                parameter = Client.Parameters;
                parameter.Add("object_id", ObjectId);
                parameter.Add("message", Message);
                parameter.Add("description", Description);
                var response = await Client.GetConnection().InvokeAsync<IdoitResponse>("cmdb.logbook.create", parameter);
                if (!response.success)
                    throw new IdoitBadResponseException(response.message);
                Id = response.id;
            });
            t.Wait();
            return Id;
        }
    }
}