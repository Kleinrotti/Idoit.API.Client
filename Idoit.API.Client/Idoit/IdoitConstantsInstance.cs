using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.Idoit
{
    /// <summary>
    /// Provides methods to retrieve idoits constant objects. Categories, RecordStates, ObjectTypes, RelationTypes and StaticObjects.
    /// </summary>
    public sealed class IdoitConstantsInstance : IdoitInstanceBase
    {
        private object responseConstants;
        private JObject responseJObject;
        private string key;
        private JToken value;
        private string groupName;
        private string childName;
        private string keyName;
        private string valueName;
        private IDictionary<string, string> response;

        public IdoitConstantsInstance(IdoitClient myClient) : base(myClient)
        {
        }

        //constants
        private async Task constants()
        {
            parameter = Client.Parameters;
            responseConstants = await Client.GetConnection().InvokeAsync<object>("idoit.constants", parameter);
        }

        //Read
        private IDictionary<string, string> Read()
        {
            responseJObject = (JObject)JsonConvert.DeserializeObject(responseConstants.ToString());
            response = new Dictionary<string, string>();

            foreach (var parentGroup in responseJObject)
            {
                key = parentGroup.Key;
                value = parentGroup.Value;
                if (key == groupName)
                {
                    foreach (var childGroup in value)
                    {
                        if (groupName == "categories")
                        {
                            valueName = childGroup.ToObject<JProperty>().Name;
                            if (valueName == childName)
                            {
                                foreach (var child in childGroup.First)
                                {
                                    keyName = child.First.ToString();
                                    valueName = child.ToObject<JProperty>().Name;
                                    response.AddSafe(keyName, valueName);
                                }
                            }
                        }
                        else
                        {
                            keyName = childGroup.First.ToString();
                            valueName = childGroup.ToObject<JProperty>().Name;
                            response.Add(keyName, valueName);
                        }
                    }
                }
            }
            return response;
        }

        /// <summary>
        /// Read all global idoit categories.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> with all categories.</returns>
        public IDictionary<string, string> ReadGlobalCategories()
        {
            groupName = "categories";
            childName = "g";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        /// <summary>
        /// Read all specific idoit categories.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> with all specific idoit categories.</returns>
        public IDictionary<string, string> ReadSpecificCategories()
        {
            groupName = "categories";
            childName = "s";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        /// <summary>
        /// Read all idiot object types.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> with all idoit object types.</returns>
        public IDictionary<string, string> ReadObjectTypes()
        {
            groupName = "objectTypes";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        /// <summary>
        /// Read all idoit record states.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> with all idoit record states.</returns>
        public IDictionary<string, string> ReadRecordStates()
        {
            groupName = "recordStates";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        /// <summary>
        /// Read all idoit relation types.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> with all idoi relation types.</returns>
        public IDictionary<string, string> ReadRelationTypes()
        {
            groupName = "relationTypes";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        /// <summary>
        /// Read all idoit static objects.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> with all static idoit objects.</returns>
        public IDictionary<string, string> ReadStaticObjects()
        {
            groupName = "staticObjects";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }
    }

    internal static class Extensions
    {
        public static void AddSafe(this IDictionary<string, string> dictionary, string key, string value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
        }
    }
}