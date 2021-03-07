using System.Collections.Generic;

namespace Idoit.API.Client
{
    public abstract class IdoitApiBase
    {
        protected IdoitClient client;
        protected Dictionary<string, object> parameter;

        public IdoitApiBase(IdoitClient myClient)
        {
            client = myClient;
        }
    }
}