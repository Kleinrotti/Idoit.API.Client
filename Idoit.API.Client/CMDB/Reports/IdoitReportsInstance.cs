using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Reports
{
    public class IdoitReportsInstance : IdoitInstanceBase, IReadable<IdoitReportsResponse[]>
    {
        public IdoitReportsInstance(IClient myClient) : base(myClient)
        {
        }

        private IdoitReportsResponse[] response;

        public IdoitReportsResponse[] Read()
        {
            Task t = Task.Run(async () =>
            {
                parameter = Client.Parameters;
                response = await Client.GetConnection().InvokeAsync<IdoitReportsResponse[]>("cmdb.reports.read", parameter);
            });
            t.Wait();
            return response;
        }

        public IdoitReportsResponse[] Read(int objId)
        {
            Task t = Task.Run(async () =>
            {
                parameter = Client.Parameters;
                parameter.Add("id", objId);
                response = await Client.GetConnection().InvokeAsync<IdoitReportsResponse[]>("cmdb.reports.read", parameter);
            });
            t.Wait();
            return response;
        }
    }
}