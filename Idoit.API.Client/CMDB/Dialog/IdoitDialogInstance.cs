using Idoit.API.Client.CMDB.Dialog.Response;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Dialog
{
    public class IdoitDialogInstance : IdoitApiBase
    {
        private DialogResult[] result;
        public string Property { get; private set; }
        public string Value { get; private set; }

        public IdoitDialogInstance(IdoitClient myClient) : base(myClient)
        {
            Client = myClient;
        }

        /// <summary>
        /// Create an idoit dialog object
        /// </summary>
        /// <param name="value"></param>
        /// <param name="property"></param>
        /// <param name="category"></param>
        /// <returns>The id of the created object</returns>
        public int Create(string value, string property, string category)
        {
            Value = value;
            Property = property;
            Category = category;
            Task t = Task.Run(() => { Creating().Wait(); }); t.Wait();
            return Id;
        }

        private async Task Creating()
        {
            parameter = Client.Parameters;
            parameter.Add("value", Value);
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<DialogResponse>
            ("cmdb.dialog.create", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.entryId.ToString());
            }
            Id = response.entryId;
        }

        /// <summary>
        /// Update an idoit dialog object
        /// </summary>
        /// <param name="entryId"></param>
        /// <param name="value"></param>
        /// <param name="property"></param>
        /// <param name="category"></param>
        public void Update(int entryId, string value, string property, string category)
        {
            Value = value;
            Property = property;
            Category = category;

            Task t = Task.Run(() => { Updating(entryId).Wait(); }); t.Wait();
        }

        private async Task Updating(int entryId)
        {
            parameter = Client.Parameters;
            parameter.Add("value", Value);
            parameter.Add("entry_id", entryId);
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<DialogResponse>
            ("cmdb.dialog.update", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.entryId.ToString());
            }
        }

        /// <summary>
        /// Delete an idoit dialog object
        /// </summary>
        /// <param name="entryId"></param>
        /// <param name="property"></param>
        /// <param name="category"></param>
        public void Delete(int entryId, string property, string category)
        {
            Property = property;
            Category = category;
            Task t = Task.Run(() => { Deleting(entryId).Wait(); }); t.Wait();
        }

        private async Task Deleting(int entryId)
        {
            //The return Values as Object from diffrence Classes
            parameter = Client.Parameters;
            parameter.Add("entry_id", entryId);
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<DialogResponse>
            ("cmdb.dialog.delete", parameter);
            if (!response.success)
            {
                throw new IdoitBadResponseException(response.entryId.ToString());
            }
        }

        /// <summary>
        /// Read an idoit dialog object
        /// </summary>
        /// <param name="property"></param>
        /// <param name="category"></param>
        /// <returns>A <see cref="DialogResult[]"/> which contains all found objects</returns>
        public DialogResult[] Read(string property, string category)
        {
            Property = property;
            Category = category;
            Task t = Task.Run(() => { Reading().Wait(); }); t.Wait();
            return result;
        }

        private async Task Reading()
        {
            parameter = Client.Parameters;
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            result = await Client.GetConnection().InvokeAsync<DialogResult[]>
            ("cmdb.dialog.read", parameter);
        }
    }
}