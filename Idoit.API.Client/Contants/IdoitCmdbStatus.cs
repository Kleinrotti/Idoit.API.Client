namespace Idoit.API.Client.Contants
{
    /// <summary>
    /// CMDB states which idoit provides.
    /// </summary>
    public enum IdoitCmdbStatus
    {
        PLANNED = 1,
        ORDERED,
        DELIVERED,
        ASSEMBLED,
        TESTED,
        INOPERATION,
        DEFECT,
        UNDER_REPAIR,
        DELIVERED_FROM_REPAIR,
        INOPERATIVE,
        STORED,
        SCRAPPED,
    }
}