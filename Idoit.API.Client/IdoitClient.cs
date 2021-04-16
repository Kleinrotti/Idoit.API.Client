using Anemonis.JsonRpc.ServiceClient;
using Idoit.API.Client.Idoit;
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
    public class IdoitClient : IClient
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

        public string Username { get; set; }

        public string Password { get; set; }

        private static IdoitLoginResponse _lastLoginResponse;

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

        public IdoitLogoutResponse Logout()
        {
            var t = Task.Run(() => { return GetConnection().InvokeAsync<IdoitLogoutResponse>("idoit.logout", Parameters); });
            _lastLoginResponse = null;
            return t.Result;
        }

        public IdoitLoginResponse Login()
        {
            if (_lastLoginResponse != null)
                return _lastLoginResponse;
            var t = Task.Run(() => { return GetConnection().InvokeAsync<IdoitLoginResponse>("idoit.login", Parameters); });
            _lastLoginResponse = t.Result;
            return _lastLoginResponse;
        }

        public JsonRpcClient GetConnection()
        {
            if (RpcClient == null)
            {
                RpcClient = new JsonRpcClient(Url, GetClient());
            }
            return RpcClient;
        }

        /// <summary>
        /// Create an authenticated HttpClient
        /// </summary>
        /// <returns>A new <see cref="HttpClient"/></returns>
        protected HttpClient GetClient()
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