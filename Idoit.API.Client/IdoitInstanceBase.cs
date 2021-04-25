using System.Collections.Generic;

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
    }
}