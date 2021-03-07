using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.Idoit
{
    public class IdoitConstantsInstance : IdoitApiBase
    {
        private object responseConstants;
        private JObject responseJObject;
        private string key;
        private JToken value;
        private string groupName;
        private string childName;
        private string keyName;
        private string valueName;
        private Dictionary<string, string> response;

        public IdoitConstantsInstance(IdoitClient myClient) : base(myClient)
        {
        }

        //constants
        private async Task constants()
        {
            parameter = client.GetParameter();
            responseConstants = await client.GetConnection().InvokeAsync<object>("idoit.constants", parameter);
        }

        //Read
        private Dictionary<string, string> Read()
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

        //ReadGlobalCategories
        public Dictionary<string, string> ReadGlobalCategories()
        {
            groupName = "categories";
            childName = "g";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        //ReadSpecificCategories
        public Dictionary<string, string> ReadSpecificCategories()
        {
            groupName = "categories";
            childName = "s";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        //ReadObjectTypes
        public Dictionary<string, string> ReadObjectTypes()
        {
            groupName = "objectTypes";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        // ReadRecordStates
        public Dictionary<string, string> ReadRecordStates()
        {
            groupName = "recordStates";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        //ReadRelationTypes
        public Dictionary<string, string> ReadRelationTypes()
        {
            groupName = "relationTypes";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }

        //ReadStaticObjects
        public Dictionary<string, string> ReadStaticObjects()
        {
            groupName = "staticObjects";
            Task t = Task.Run(() => { constants().Wait(); Read(); }); t.Wait();
            return response;
        }
    }

    internal static class Extensions
    {
        public static void AddSafe(this Dictionary<string, string> dictionary, string key, string value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
        }
    }
}