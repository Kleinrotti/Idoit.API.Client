using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB
{
    /// <summary>
    /// Represents a response from Idoit when executing actions.
    /// </summary>
    internal class IdoitResponse
    {
        /// <summary>
        /// Id of the modified or created idoit object.
        /// </summary>
        [JsonProperty("id")]
        public int id { get; internal set; }

        /// <summary>
        /// Response message from idoit
        /// </summary>
        [JsonProperty("message")]
        public string message { get; internal set; }

        /// <summary>
        /// Requested action was successfull
        /// </summary>
        [JsonProperty("success")]
        public bool success { get; internal set; }
    }
}