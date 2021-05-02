using Idoit.API.Client.CMDB.Logbook;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdoitUnitTests.CMDB
{
    [TestClass]
    public class LogbookTest : IdoitTestBase
    {
        public LogbookTest() : base()
        {
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            var request = new IdoitLogbookInstance(idoitClient);
            var result = request.Read();
        }

        [TestMethod]
        public void CreateTest()
        {
            var request = new IdoitLogbookInstance(idoitClient);
            request.Message = "Just a test";
            request.ObjectId = 100;
            var result = request.Create();
        }
    }
}