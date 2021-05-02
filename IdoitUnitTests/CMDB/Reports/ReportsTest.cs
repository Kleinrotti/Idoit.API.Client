using Idoit.API.Client.CMDB.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IdoitUnitTests.CMDB
{
    [TestClass]
    public class ReportsTest : IdoitTestBase
    {
        public ReportsTest() : base()
        {
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            var request = new IdoitReportsInstance(idoitClient);
            var result = request.Read();

            Assert.IsFalse(result.Length == 0);

            foreach (var v in result)
            {
                Console.WriteLine(v.title);
            }
        }
    }
}