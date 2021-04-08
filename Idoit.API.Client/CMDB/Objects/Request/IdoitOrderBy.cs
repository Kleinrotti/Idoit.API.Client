namespace Idoit.API.Client.CMDB.Objects
{
    /// <summary>
    /// Use the extension method GetStringValue for the actual values!
    /// </summary>
    public enum IdoitOrderBy
    {
        [StringValue("type")]
        Type = 0,

        [StringValue("title")]
        Title,

        [StringValue("type_title")]
        TypeTitle,

        [StringValue("sysid")]
        SysId,

        [StringValue("first_name")]
        FirstNam,

        [StringValue("last_name")]
        LastName,

        [StringValue("email")]
        Email,

        [StringValue("id")]
        Id,

        [StringValue(null)]
        None,
    }
}