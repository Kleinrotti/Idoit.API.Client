﻿using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Category
{
    /// <summary>
    /// Represents a class for Idoit MultiValue items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class IdoitMvcInstance<T> : IdoitCategoryInstance<T>, IDeletable where T : IMultiValueResponse, new()
    {
        /// <summary>
        /// Initializes a new instance of the IdoitMvcInstance class.
        /// </summary>
        /// <param name="myClient"></param>
        public IdoitMvcInstance(IdoitClient myClient) : base(myClient)
        {
            Object = new T();
            Category = Object.category_id;
        }

        /// <summary>
        /// Deletes the given object. Property ObejectId and EntryId has to be set.
        /// </summary>
        public void Delete()
        {
            Task t = Task.Run(() => { Deleting().Wait(); }); t.Wait();
        }

        private async Task Deleting()
        {
            //The return Values as Object from diffrence Classes
            parameter = Client.Parameters;
            parameter.Add("objID", ObjectId);
            parameter.Add("cateID", EntryId);
            parameter.Add("category", Category);
            var result = await Client.GetConnection().InvokeAsync<IdoitResponse>
            ("cmdb.category.delete", parameter);
            if (!result.success)
            {
                throw new IdoitBadResponseException(result.message);
            }
        }
    }
}