using System.Collections.Generic;

namespace Idoit.API.Client
{
    /// <summary>
    /// Reprents a base class for the Idoit API.
    /// </summary>
    public abstract class IdoitApiBase
    {
        /// <summary>
        /// Returns the current <see cref="IdoitClient"/>
        /// </summary>
        public IdoitClient Client { get; protected set; }

        /// <summary>
        /// Returns the Id of the newly created or updated object
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Returns the unique identifier of the idoit category
        /// </summary>
        public string Category { get; protected set; }

        protected Dictionary<string, object> parameter;

        public IdoitApiBase(IdoitClient myClient)
        {
            Client = myClient;
        }
    }
}