namespace Idoit.API.Client.CMDB.Object
{
    public class IdoitObjectTypesFilter : IFilter
    {
        public int[] ids { get; set; }
        public string title { get; set; }

        /// <summary>
        /// Filter by single id.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Filter by multiple titles.
        /// </summary>
        public string[] titles { get; set; }

        /// <summary>
        /// Filter if object type is enabled in the GUI.
        /// </summary>
        public bool enabled { get; set; }
    }
}