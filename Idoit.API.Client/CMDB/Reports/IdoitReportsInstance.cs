namespace Idoit.API.Client.CMDB.Reports
{
    /// <summary>
    /// Provides methods for Reports.
    /// </summary>
    public class IdoitReportsInstance : IdoitInstanceBase, IReadable<IdoitReportsResponse[]>
    {
        public IdoitReportsInstance(IClient myClient) : base(myClient)
        {
        }

        /// <summary>
        /// Read all reports.
        /// </summary>
        /// <returns>An <see cref="IdoitReportsResponse"/> array.</returns>
        public IdoitReportsResponse[] Read()
        {
            parameter = Client.Parameters;
            return Execute<IdoitReportsResponse[]>("cmdb.reports.read");
        }

        /// <summary>
        /// Read a specific report.
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public IdoitReportsResponse[] Read(int objId)
        {
            parameter = Client.Parameters;
            parameter.Add("id", objId);
            return Execute<IdoitReportsResponse[]>("cmdb.reports.read");
        }
    }
}