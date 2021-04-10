using Newtonsoft.Json;

namespace Idoit.API.Client
{
    public interface IFilter
    {
        /// <summary>
        /// Filter by multiple ids.
        /// </summary>
        int[] ids { get; set; }

        /// <summary>
        /// Filter by name of the object.
        /// </summary>
        string title { get; set; }

        /// <summary>
        /// Returns the current object without null value properties.
        /// </summary>
        /// <returns></returns>
        object GetObject()
        {
            string Json = JsonConvert.SerializeObject(this, new JsonSerializerSettings
            { DefaultValueHandling = DefaultValueHandling.Ignore });
            object data = JsonConvert.DeserializeObject(Json);
            return data;
        }
    }
}