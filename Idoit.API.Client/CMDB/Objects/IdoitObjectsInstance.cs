﻿using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Objects
{
    /// <summary>
    /// Provides methods to read multiple objects from idoit. Filtering is also supported
    /// </summary>
    public class IdoitObjectsInstance : IdoitInstanceBase, IReadable<IdoitObjectsResult[]>
    {
        public IdoitObjectsInstance(IdoitClient myClient) : base(myClient)
        {
            Client = myClient;
        }

        private IdoitObjectsResult[] response;

        /// <summary>
        /// Advanced filtering for the searched result.
        /// </summary>
        public IFilter Filter { get; set; }

        /// <summary>
        /// Order the searched result.
        /// </summary>
        public IdoitOrderBy OrderBy { get; set; }

        /// <summary>
        /// Sort the searched result.
        /// </summary>
        public IdoitSort Sort { get; set; }

        /// <summary>
        /// Limit the searched result. Where to start and number of elements, i.e. 0 or 0,10.
        /// </summary>
        public string Limit { get; set; }

        /// <summary>
        /// Formatts the searched result as raw SQL.
        /// </summary>
        public bool Raw { get; set; }

        /// <summary>
        /// Read an idoit object. Set Filter, OrderBy, Sort or Limit Property to filter your result.
        /// </summary>
        /// <returns>An <see cref="IdoitObjectsResult"/> array with all found objects.</returns>
        public IdoitObjectsResult[] Read()
        {
            Task t = Task.Run(() => { Reading().Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading()
        {
            //object data = Client.GetData(Filter);
            parameter = Client.Parameters;
            parameter.Add("filter", Filter.GetObject());
            parameter.Add("sort", Sort.GetStringValue());
            parameter.Add("limit", Limit);
            parameter.Add("order_by", OrderBy.GetStringValue());
            parameter.Add("raw", Raw);
            response = await Client.GetConnection().InvokeAsync<IdoitObjectsResult[]>("cmdb.objects.read", parameter);
        }
    }
}