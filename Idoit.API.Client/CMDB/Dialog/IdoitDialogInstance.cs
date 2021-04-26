using Idoit.API.Client.Contants;

namespace Idoit.API.Client.CMDB.Dialog
{
    public class IdoitDialogInstance : IdoitInstanceBase, IReadable<DialogResult[]>, ICreatable, IUpdatable, IDeletable
    {
        /// <summary>
        /// Attribute in category, e.g manufacturer.
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Entry identifier.
        /// </summary>
        public int EntryId { get; set; }

        /// <summary>
        /// Category constant. Found in <see cref="IdoitCategory"/>.
        /// </summary>
        public new string Category { get; set; }

        public IdoitDialogInstance(IClient myClient) : base(myClient)
        {
        }

        /// <summary>
        /// Create an idoit dialog object. Property Value, Property and Category has to be set.
        /// </summary>
        /// <returns>The id of the created object</returns>
        public int Create()
        {
            parameter = Client.Parameters;
            parameter.Add("value", Value);
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            var response = Execute<DialogResponse>("cmdb.dialog.create");
            if (!response.success)
                throw new IdoitBadResponseException(response.entryId.ToString());
            Id = response.entryId;
            return Id;
        }

        /// <summary>
        /// Update an idoit dialog object. Property CateId, Value, Property and Category has to be set.
        /// </summary>
        public void Update()
        {
            parameter = Client.Parameters;
            parameter.Add("value", Value);
            parameter.Add("entry_id", EntryId);
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            var response = Execute<DialogResponse>("cmdb.dialog.update");
            if (!response.success)
                throw new IdoitBadResponseException(response.entryId.ToString());
        }

        /// <summary>
        /// Delete an idoit dialog object. Property CateId, Property and Category has to be set.
        /// </summary>
        public void Delete()
        {
            parameter = Client.Parameters;
            parameter.Add("entry_id", EntryId);
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            var response = Execute<DialogResponse>("cmdb.dialog.delete");
            if (!response.success)
                throw new IdoitBadResponseException(response.entryId.ToString());
        }

        /// <summary>
        /// Read an idoit dialog object. Property Category and Property has to be set.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> array, which contains all found objects.</returns>
        public DialogResult[] Read()
        {
            parameter = Client.Parameters;
            parameter.Add("property", Property);
            parameter.Add("category", Category);
            return Execute<DialogResult[]>("cmdb.dialog.read");
        }
    }
}