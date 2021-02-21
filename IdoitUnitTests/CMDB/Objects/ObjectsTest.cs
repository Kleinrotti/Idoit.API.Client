using Idoit.API.Client.CMDB.Objects;
using Idoit.API.Client.CMDB.Objects.Request;
using Idoit.API.Client.CMDB.Objects.Response;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ObjectCreate = Idoit.API.Client.CMDB.Object.IdoitObject;

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
            var lists = new List<IdoitResult[]>();
            var request = new IdoitObjects(idoitClient);
            ObjectCreate requestCreate = new ObjectCreate(idoitClient);
            Filter filter = new Filter();
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
            request.orderBy = OrderBy.Title;
            request.sort = Sort.Acsending;
            filter.ids = new int[] { ObjectId[0], ObjectId[8] };
            filter.type = "C__OBJTYPE__SERVICE";
            //filter.title = "SystemService";
            lists = request.Read(filter);

            //Assert
            foreach (IdoitResult[] row in lists)
            {
                foreach (IdoitResult element in row)
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