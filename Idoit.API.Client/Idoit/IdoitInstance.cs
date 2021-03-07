using Idoit.API.Client.Idoit.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.Idoit
{
    public class IdoitInstance
    {
        public IdoitClient client;
        private List<IdoitSearchResponse[]> responseSearch;
        private IdoitLogoutResponse responseLogout = new IdoitLogoutResponse();
        private IdoitLoginResponse responseLogin = new IdoitLoginResponse();
        private IdoitVersionResponse responseVersion;
        private Dictionary<string, object> parameter;

        public IdoitInstance(IdoitClient myClient)
        {
            client = myClient;
        }

        //Version
        public IdoitVersionResponse Version()
        {
            Task t = Task.Run(() => { version().Wait(); }); t.Wait();
            return responseVersion;
        }

        //version
        private async Task version()
        {
            responseVersion = await client.GetConnection().InvokeAsync<IdoitVersionResponse>("idoit.version", client.GetParameter());
        }

        //Search
        public List<IdoitSearchResponse[]> Search(string q)
        {
            Task t = Task.Run(() => { search(q).Wait(); }); t.Wait();
            return responseSearch;
        }

        //Search
        private async Task search(string q)
        {
            parameter = client.GetParameter();
            parameter.Add("q", q);
            responseSearch = new List<IdoitSearchResponse[]>();
            responseSearch.Add(await client.GetConnection().InvokeAsync<IdoitSearchResponse[]>("idoit.search", parameter));
        }

        //Logout
        public IdoitLogoutResponse Logout()
        {
            Task t = Task.Run(() => { logout().Wait(); }); t.Wait();
            return responseLogout;
        }

        //logout
        private async Task logout()
        {
            parameter = client.GetParameter();
            responseLogout = await client.GetConnection().InvokeAsync<IdoitLogoutResponse>("idoit.logout", parameter);
        }

        //Login
        public IdoitLoginResponse Login()
        {
            Task t = Task.Run(() => { login().Wait(); }); t.Wait();
            return responseLogin;
        }

        //login
        private async Task login()
        {
            parameter = client.GetParameter();
            responseLogin = await client.GetConnection().InvokeAsync<IdoitLoginResponse>("idoit.login", parameter);
        }
    }
}