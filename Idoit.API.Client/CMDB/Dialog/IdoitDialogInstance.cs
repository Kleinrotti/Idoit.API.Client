using Idoit.API.Client.CMDB.Dialog.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idoit.API.Client.CMDB.Dialog
{
    public class IdoitDialogInstance
    {
        private List<DialogResult[]> result;
        public int Id;
        public IdoitClient Client { get; }
        public string Property { get; set; }
        public string Value { get; set; }
        public string Category { get; set; }
        private Dictionary<string, object> parameter;

        public IdoitDialogInstance(IdoitClient myClient)
        {
            Client = myClient;
        }

        //Create
        public int Create()
        {
            if (Property == null)
            {
                throw new ArgumentException("Property is missing");
            }
            else if (Value == null)
            {
                throw new ArgumentException("Value is missing");
            }
            else if (Category == null)
            {
                throw new ArgumentException("Category is missing");
            }
            Task t = Task.Run(() => { Creating().Wait(); }); t.Wait();
            return Id;
        }

        private async Task Creating()
        {
            parameter = Client.GetParameter();
            parameter.Add("value", Value);
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<DialogResponse>
            ("cmdb.dialog.create", parameter);
            Id = response.entryId;
        }

        //Update
        public void Update(int entryId)
        {
            if (entryId == null)
            {
                throw new ArgumentException("Entry_id is missing");
            }
            else if (Property == null)
            {
                throw new ArgumentException("Property is missing");
            }
            else if (Value == null)
            {
                throw new ArgumentException("Value is missing");
            }
            else if (Category == null)
            {
                throw new ArgumentException("Category is missing");
            }

            Task t = Task.Run(() => { Updating(entryId).Wait(); }); t.Wait();
        }

        private async Task Updating(int entryId)
        {
            parameter = Client.GetParameter();
            parameter.Add("value", Value);
            parameter.Add("entry_id", entryId);
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<DialogResponse>
            ("cmdb.dialog.update", parameter);
        }

        //Delete
        public void Delete(int entryId)
        {
            if (entryId == null)
            {
                throw new ArgumentException("Entry_id is missing");
            }
            else if (Property == null)
            {
                throw new ArgumentException("Property is missing");
            }
            else if (Category == null)
            {
                throw new ArgumentException("Category is missing");
            }

            Task t = Task.Run(() => { Deleting(entryId).Wait(); }); t.Wait();
        }

        private async Task Deleting(int entryId)
        {
            //The return Values as Object from diffrence Classes
            parameter = Client.GetParameter();
            parameter.Add("entry_id", entryId);
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            var response = await Client.GetConnection().InvokeAsync<DialogResponse>
            ("cmdb.dialog.delete", parameter);
        }

        //Read
        public List<DialogResult[]> Read()
        {
            Task t = Task.Run(() => { Reading().Wait(); }); t.Wait();
            return result;
        }

        private async Task Reading()
        {
            parameter = Client.GetParameter();
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            result = new List<DialogResult[]>();
            result.Add(await Client.GetConnection().InvokeAsync<DialogResult[]>
            ("cmdb.dialog.read", parameter));
        }
    }
}