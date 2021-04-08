using Idoit.API.Client.Idoit.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.Idoit
{
    /// <summary>
    /// Provides methods to retrieve the idoit version and search for objects.
    /// </summary>
    public class IdoitInstance : IdoitApiBase
    {
        private IList<IdoitSearchResponse[]> responseSearch;
        private IdoitVersionResponse responseVersion;

        public IdoitInstance(IdoitClient myClient) : base(myClient)
        {
        }

        /// <summary>
        /// Retrieve the current idoit version.
        /// </summary>
        /// <returns>A <see cref="IdoitVersionResponse"/></returns>
        public IdoitVersionResponse Version()
        {
            Task t = Task.Run(() => { version().Wait(); }); t.Wait();
            return responseVersion;
        }

        //version
        private async Task version()
        {
            responseVersion = await Client.GetConnection().InvokeAsync<IdoitVersionResponse>("idoit.version", Client.Parameters);
        }

        /// <summary>
        /// Search for a specific keyword.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>A <see cref="IList{T}"/> with all objects found.</returns>
        public IList<IdoitSearchResponse[]> Search(string keyword)
        {
            Task t = Task.Run(() => { search(keyword).Wait(); }); t.Wait();
            return responseSearch;
        }

        //Search
        private async Task search(string q)
        {
            parameter = Client.Parameters;
            parameter.Add("q", q);
            responseSearch = new List<IdoitSearchResponse[]>();
            responseSearch.Add(await Client.GetConnection().InvokeAsync<IdoitSearchResponse[]>("idoit.search", parameter));
        }
    }
}