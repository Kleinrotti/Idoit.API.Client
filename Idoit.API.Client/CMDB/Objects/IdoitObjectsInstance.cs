using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Objects
{
    public class IdoitObjectsInstance : IdoitApiBase
    {
        public IdoitObjectsInstance(IdoitClient myClient) : base(myClient)
        {
            Client = myClient;
        }

        private IdoitObjectsResult[] response;
        public string Type { get; set; }
        public string Title { get; set; }
        public string Purpose { get; set; }
        public string CmdbStatus { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Read an idoit object
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="limit"></param>
        /// <param name="orderBy"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IdoitObjectsResult[] Read(IdoitFilter filter, IdoitOrderBy orderBy, IdoitSort sort, string limit = null)
        {
            Task t = Task.Run(() => { Reading(filter, limit, orderBy.GetStringValue(), sort.GetStringValue()).Wait(); }); t.Wait();
            return response;
        }

        private async Task Reading(IdoitFilter filter, string limit, string orderBy, string sort)
        {
            object data = Client.GetData(filter);
            parameter = Client.Parameters;
            parameter.Add("filter", data);
            parameter.Add("sort", sort);
            parameter.Add("limit", limit);
            parameter.Add("order_by", orderBy);
            response = await Client.GetConnection().InvokeAsync<IdoitObjectsResult[]>("cmdb.objects.read", parameter);
        }
    }
}