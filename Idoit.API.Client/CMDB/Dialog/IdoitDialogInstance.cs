using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Dialog
{
    public class IdoitDialogInstance : IdoitInstanceBase, IReadable<DialogResult[]>, ICreatable, IUpdatable, IDeletable
    {
        private DialogResult[] result;
        public string Property { get; set; }
        public int EntryId { get; set; }
        public new string Category { get; set; }

        public IdoitDialogInstance(IClient myClient) : base(myClient)
        {
            Client = myClient;
        }

        /// <summary>
        /// Create an idoit dialog object. Property Value, Property and Category has to be set.
        /// </summary>
        /// <returns>The id of the created object</returns>
        public int Create()
        {
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
        /// Update an idoit dialog object. Property EntryId, Value, Property and Category has to be set.
        /// </summary>
        public void Update()
        {
            Task t = Task.Run(() => { Updating().Wait(); }); t.Wait();
        }

        private async Task Updating()
        {
            parameter = Client.Parameters;
            parameter.Add("value", Value);
            parameter.Add("entry_id", EntryId);
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
        /// Delete an idoit dialog object. Property EntryId, Property and Category has to be set.
        /// </summary>
        public void Delete()
        {
            Task t = Task.Run(() => { Deleting().Wait(); }); t.Wait();
        }

        private async Task Deleting()
        {
            //The return Values as Object from diffrence Classes
            parameter = Client.Parameters;
            parameter.Add("entry_id", EntryId);
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
        /// Read an idoit dialog object. Property Category and Property has to be set.
        /// </summary>
        /// <returns>A <see cref="DialogResult[]"/> which contains all found objects</returns>
        public DialogResult[] Read()
        {
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