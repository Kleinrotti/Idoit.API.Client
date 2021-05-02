using Idoit.API.Client.CMDB.Impact;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdoitUnitTests.CMDB
{
    [TestClass]
    public class ImpactTest : IdoitTestBase
    {
        public ImpactTest() : base()
        {
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            var request = new IdoitImpactInstance(idoitClient);
            request.ObjectId = 10;
            request.RelationType = 10;
            var result = request.Read();
        }
    }
}