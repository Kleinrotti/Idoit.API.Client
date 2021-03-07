using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Obj = Idoit.API.Client.CMDB.Object.IdoitObjectInstance;

namespace IdoitUnitTests
{
    //[Ignore]
    [TestClass]
    public class LocationCategoryTest : IdoitTestBase
    {
        public LocationCategoryTest() : base()
        {
        }

        //[Ignore]
        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            int cateId, objectId;
            var list = new List<LocationResponse[]>();
            var categoryRequest = new LocationRequest();
            Obj objectRequest = new Obj(idoitClient);
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);
            //Act:Create the Object
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Title = " My IdoitClient";

            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category

            categoryRequest.description = "Web GUI description";
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            cateId = Location.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            list = Location.Read(objectId);

            //Assert
            foreach (LocationResponse[] row in list)
            {
                foreach (LocationResponse element in row)
                {
                    Assert.IsNotNull(element.id);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        //[Ignore]
        //Quickpurge
        [TestMethod]
        public void QuickpurgeTest()
        {
            //Arrange
            int cateId, objectId;
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new LocationRequest();
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Title = " My IdoitClient";
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";
            cateId = Location.Create(objectId, categoryRequest);

            //Act
            Location.Quickpurge(objectId, cateId);
        }

        //[Ignore]
        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
            List<LocationResponse[]> list = new List<LocationResponse[]>();
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new LocationRequest();
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Title = " My IdoitClient";
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";

            cateId = Location.Create(objectId, categoryRequest);

            //Act: Update the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI 2 description";

            Location.Update(objectId, categoryRequest);

            //Act:Read the Category
            list = Location.Read(objectId);

            //Assert
            foreach (LocationResponse[] row in list)
            {
                foreach (LocationResponse element in row)
                {
                    Assert.AreEqual("Web GUI 2 description", element.description);
                }
            }
            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        //[Ignore]
        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int cateId, objectId;
            var list = new List<LocationResponse[]>();
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new LocationRequest();
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Title = " My IdoitClient";
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";

            cateId = Location.Create(objectId, categoryRequest);

            //Act:Read the Category
            list = Location.Read(objectId);

            //Assert
            foreach (LocationResponse[] row in list)
            {
                foreach (LocationResponse element in row)
                {
                    Assert.AreEqual("Web GUI description", categoryRequest.description);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}