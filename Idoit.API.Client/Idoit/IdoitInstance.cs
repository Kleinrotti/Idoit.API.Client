namespace Idoit.API.Client.Idoit
{
    /// <summary>
    /// Provides methods to retrieve the idoit version and search for objects.
    /// </summary>
    public class IdoitInstance : IdoitInstanceBase
    {
        private IdoitSearchResponse[] responseSearch;

        public IdoitInstance(IClient myClient) : base(myClient)
        {
        }

        /// <summary>
        /// Retrieve the current idoit version.
        /// </summary>
        /// <returns>A <see cref="IdoitVersionResponse"/></returns>
        public IdoitVersionResponse Version()
        {
            parameter = Client.Parameters;
            return Execute<IdoitVersionResponse>("idoit.version");
        }

        /// <summary>
        /// Search for a specific keyword.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>A <see cref="IdoitSearchResponse"/>[] with all objects found.</returns>
        public IdoitSearchResponse[] Search(string keyword)
        {
            parameter = Client.Parameters;
            parameter.Add("q", keyword);
            return Execute<IdoitSearchResponse[]>("idoit.search");
        }

        /// <summary>
        /// Read information about installed addons.
        /// </summary>
        /// <returns></returns>
        public object Addons()
        {
            parameter = Client.Parameters;
            return Execute<object>("idoit.addons.read");
        }

        /// <summary>
        /// Read license information.
        /// </summary>
        /// <returns></returns>
        public object License()
        {
            parameter = Client.Parameters;
            return Execute<object>("idoit.license.read");
        }
    }
}