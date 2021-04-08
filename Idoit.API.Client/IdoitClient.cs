using Anemonis.JsonRpc.ServiceClient;
using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.CMDB.Objects;
using Idoit.API.Client.Idoit.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Idoit.API.Client
{
    /// <summary>
    /// Represents an Idoit API client.
    /// </summary>
    public sealed class IdoitClient
    {
        /// <summary>
        /// Idoit server Url
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Idoit API key
        /// </summary>
        public string Apikey { get; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// Idoit username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Idoit user password
        /// </summary>
        public string Password { get; set; }

        private static IdoitLoginResponse _lastLoginResponse;

        /// <summary>
        /// Returns the current used connection parameters
        /// </summary>
        public Dictionary<string, object> Parameters
        {
            get
            {
                var parameters = new Dictionary<string, object>
                {
                    ["apikey"] = Apikey,
                    ["language"] = Language
                };
                return parameters;
            }
        }

        private JsonRpcClient RpcClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdoitClient"/> class.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="apikey"></param>
        /// <param name="language"></param>
        public IdoitClient(string url, string apikey, string language)
        {
            Language = language;
            Apikey = apikey;
            Url = url;
        }

        /// <summary>
        /// Logout the current idoit session.
        /// </summary>
        /// <returns></returns>
        public IdoitLogoutResponse Logout()
        {
            var t = Task.Run(() => { return GetConnection().InvokeAsync<IdoitLogoutResponse>("idoit.logout", Parameters); });
            _lastLoginResponse = null;
            return t.Result;
        }

        /// <summary>
        /// Login to idoit to keep a session connected instead of creating new ones
        /// </summary>
        /// <returns></returns>
        public IdoitLoginResponse Login()
        {
            if (_lastLoginResponse != null)
                return _lastLoginResponse;
            var t = Task.Run(() => { return GetConnection().InvokeAsync<IdoitLoginResponse>("idoit.login", Parameters); });
            _lastLoginResponse = t.Result;
            return _lastLoginResponse;
        }

        /// <summary>
        /// Initialize a rpc connection.
        /// </summary>
        /// <returns>The current <see cref="JsonRpcClient"/></returns>
        public JsonRpcClient GetConnection()
        {
            if (RpcClient == null)
            {
                RpcClient = new JsonRpcClient(Url, GetClient());
            }
            return RpcClient;
        }

        /// <summary>
        /// Convert an <see cref="IRequest"/> to an data object
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The converted <see cref="IRequest"/> object</returns>
        public object GetData(IRequest request)
        {
            string Json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            { DefaultValueHandling = DefaultValueHandling.Ignore });
            object data = JsonConvert.DeserializeObject(Json);
            return data;
        }

        /// <summary>
        /// Convert an <see cref="IdoitFilter"/> to an data object
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>The converted <see cref="IdoitFilter"/> object</returns>
        public object GetData(IdoitFilter filter)
        {
            string Json = JsonConvert.SerializeObject(filter, new JsonSerializerSettings
            { DefaultValueHandling = DefaultValueHandling.Ignore });
            object data = JsonConvert.DeserializeObject(Json);
            return data;
        }

        /// <summary>
        /// Create an authenticated HttpClient
        /// </summary>
        /// <returns>A new <see cref="HttpClient"/></returns>
        public HttpClient GetClient()
        {
            if (_lastLoginResponse == null)
            {
                var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Username}:{Password}")));
                var client = new HttpClient()
                {
                    DefaultRequestHeaders = { Authorization = authValue }
                };
                return client;
            }
            else
            {
                var authValue = new AuthenticationHeaderValue("Session", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_lastLoginResponse.sessionId}")));
                var client = new HttpClient()
                {
                    DefaultRequestHeaders = { Authorization = authValue }
                };
                return client;
            }
        }
    }
}