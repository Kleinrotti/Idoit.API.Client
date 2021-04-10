using Anemonis.JsonRpc.ServiceClient;
using Idoit.API.Client.Idoit.Response;
using System.Collections.Generic;

namespace Idoit.API.Client
{
    /// <summary>
    /// Provides methods to connect to an idoit server.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Logout the current idoit session.
        /// </summary>
        /// <returns>An <see cref="IdoitLogoutResponse"/></returns>
        IdoitLogoutResponse Logout();

        /// <summary>
        /// Login to idoit to keep a session connected instead of creating new ones
        /// </summary>
        /// <returns>An <see cref="IdoitLoginResponse"/></returns>
        IdoitLoginResponse Login();

        /// <summary>
        /// Initialize a rpc connection.
        /// </summary>
        /// <returns>The current <see cref="JsonRpcClient"/></returns>
        JsonRpcClient GetConnection();

        /// <summary>
        /// Returns the current used connection parameters
        /// </summary>
        Dictionary<string, object> Parameters { get; }

        /// <summary>
        /// Idoit username
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Idoit user password
        /// </summary>
        public string Password { get; }
    }
}