using Idoit.API.Client.CMDB;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.CMDB.Objects;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdoitUnitTests
{
    [TestClass]
    public class ObjectsTest : IdoitTestBase
    {
        public ObjectsTest() : base()
        {
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            var request = new IdoitObjectsInstance(idoitClient);
            var requestCreate = new IdoitObjectInstance(idoitClient);
            var filter = new IdoitObjectsFilter();
            int[] ObjectId = new int[10];

            //Act:Create the Objects
            for (int i = 0; i < 10; i++)
            {
                requestCreate.CmdbStatus = IdoitCmdbStatus.PLANNED;
                requestCreate.Type = IdoitObjectTypes.SYSTEM_SERVICE;
                requestCreate.Value = " System Service " + i;
                ObjectId[i] = requestCreate.Create();
            }

            //Act : Read Objects
            filter.ids = new int[] { ObjectId[0], ObjectId[8] };
            filter.type = IdoitObjectTypes.SERVICE;
            //filter.title = "SystemService";
            request.Filter = filter;
            request.OrderBy = IdoitOrderBy.Title;
            request.Sort = IdoitSort.Acsending;
            request.Limit = "0,10";
            var lists = request.Read();
            Assert.IsTrue(lists.Length > 0, "No objects found");
            //Assert

            foreach (var v in lists)
            {
                Assert.IsNotNull(v.title);
                Assert.IsNotNull(v.id);
            }

            //Act:Delete the Objects
            for (int i = 0; i < 10; i++)
            {
                requestCreate.ObjectId = ObjectId[i];
                requestCreate.Purge();
            }
        }
    }
}