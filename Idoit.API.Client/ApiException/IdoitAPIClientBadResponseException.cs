using System;
using System.Runtime.Serialization;

namespace Idoit.API.Client.ApiException
{
    public class IdoitAPIClientBadResponseException : Exception
    {
        // Constructors
        public IdoitAPIClientBadResponseException(string message) : base(message)
        {
        }

        // Ensure Exception is Serializable
        protected IdoitAPIClientBadResponseException(SerializationInfo info,
            StreamingContext text) : base(info, text)
        {
        }
    }
}