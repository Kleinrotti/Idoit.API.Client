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
            var filter = new IdoitFilter();
            int[] ObjectId = new int[10];

            //Act:Create the Objects
            for (int i = 0; i < 10; i++)
            {
                requestCreate.CmdbStatus = IdoitCmdbStatus.PLANNED;
                ObjectId[i] = requestCreate.Create(IdoitObjectTypes.SYSTEM_SERVICE, " System Service " + i);
            }

            //Act : Read Objects
            filter.ids = new int[] { ObjectId[0], ObjectId[8] };
            filter.type = IdoitObjectTypes.SERVICE;
            //filter.title = "SystemService";
            var lists = request.Read(filter, IdoitOrderBy.Title, IdoitSort.Acsending, "0,10");

            //Assert

            foreach (var v in lists)
            {
                Assert.IsNotNull(v.title);
                Assert.IsNotNull(v.id);
            }

            //Act:Delete the Objects
            for (int i = 0; i < 10; i++)
            {
                requestCreate.Purge(ObjectId[i]);
            }
        }
    }
}