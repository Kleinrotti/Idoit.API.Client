using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.CMDB.Objects;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            var lists = new List<IdoitObjectsResult[]>();
            var request = new IdoitObjects(idoitClient);
            var requestCreate = new IdoitObject(idoitClient);
            var filter = new IdoitFilter();
            int[] ObjectId = new int[10];

            //Act:Create the Objects
            for (int i = 0; i < 10; i++)
            {
                requestCreate.type = IdoitObjectTypes.SYSTEM_SERVICE;
                requestCreate.title = " System Service " + i;
                requestCreate.cmdbStatus = IdoitCmdbStatus.PLANNED;
                ObjectId[i] = requestCreate.Create();
            }

            //Act : Read Objects
            request.limit = "0,10";
            request.orderBy = IdoitOrderBy.Title;
            request.sort = IdoitSort.Acsending;
            filter.ids = new int[] { ObjectId[0], ObjectId[8] };
            filter.type = "C__OBJTYPE__SERVICE";
            //filter.title = "SystemService";
            lists = request.Read(filter);

            //Assert
            foreach (IdoitObjectsResult[] row in lists)
            {
                foreach (IdoitObjectsResult element in row)
                {
                    Assert.IsNotNull(element.title);
                    Assert.IsNotNull(element.id);
                }
            }

            //Act:Delete the Objects
            for (int i = 0; i < 10; i++)
            {
                requestCreate.Purge(ObjectId[i]);
            }
        }
    }
}