using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client
{
    /// <summary>
    /// Reprents a base class for the Idoit API.
    /// </summary>
    public abstract class IdoitInstanceBase : IInstance
    {
        public IClient Client { get; protected set; }

        public virtual int Id { get; protected set; }

        public virtual string Category { get; protected set; }

        public virtual string Value { get; set; }

        protected Dictionary<string, object> parameter;

        public IdoitInstanceBase(IClient myClient)
        {
            Client = myClient;
        }

        protected T Execute<T>(string idoitNamespace)
        {
            var t = Task.Run(async () =>
            {
                return await Client.GetConnection().InvokeAsync<T>(idoitNamespace, parameter);
            });
            return t.Result;
        }
    }
}