namespace Idoit.API.Client.CMDB
{
    /// <summary>
    /// Use the extension method GetStringValue for the actual values!
    /// </summary>
    public enum IdoitSort
    {
        [StringValue(null)]
        None = 0,

        [StringValue("ASC")]
        Acsending,

        [StringValue("DESC")]
        Descending
    }
}