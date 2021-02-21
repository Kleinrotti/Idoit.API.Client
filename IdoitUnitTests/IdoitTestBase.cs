using Idoit.API.Client;
using System;

namespace IdoitUnitTests
{
    public abstract class IdoitTestBase
    {
        protected string URL;
        protected string APIKEY;
        protected string LANGUAGE;
        protected IdoitClient idoitClient;

        public IdoitTestBase()
        {
            URL = Environment.GetEnvironmentVariable("IDOITURL");
            APIKEY = Environment.GetEnvironmentVariable("IDOITAPIKEY");
            LANGUAGE = "en";
            idoitClient = new IdoitClient(URL, APIKEY, LANGUAGE)
            {
                Username = "admin",
                Password = "admin"
            };
        }
    }
}