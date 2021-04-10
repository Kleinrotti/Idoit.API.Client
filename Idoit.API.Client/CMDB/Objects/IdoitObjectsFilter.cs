namespace Idoit.API.Client.CMDB.Objects
{
    /// <summary>
    /// Provides possible values to filter an idoit request.
    /// </summary>
    public class IdoitObjectsFilter : IFilter
    {
        /// <summary>
        /// Filter by multiple ids.
        /// </summary>
        public int[] ids { get; set; }

        /// <summary>
        /// Filter by Objecttype ID from table isys_obj_type.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Filter by name of the object.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Filter by name of the objecttype.
        /// </summary>
        public string type_title { get; set; }

        /// <summary>
        /// Filter by SYS-ID.
        /// </summary>
        public string sysid { get; set; }

        /// <summary>
        /// Filter by first name of a person.
        /// </summary>
        public string first_name { get; set; }

        /// <summary>
        /// Filter by last name of a person.
        /// </summary>
        public string last_name { get; set; }

        /// <summary>
        /// Filter by email adress.
        /// </summary>
        public string email { get; set; }
    }
}