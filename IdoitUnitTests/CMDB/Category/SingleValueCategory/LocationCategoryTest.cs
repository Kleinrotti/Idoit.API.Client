using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        //Quickpurge
        [TestMethod]
        public void QuickpurgeTest()
        {
            //Arrange
            int cateId, objectId;
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new LocationRequest();
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My IdoitClient";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";
            Location.ObjectId = objectId;
            Location.ObjectRequest = categoryRequest;
            cateId = Location.Create();

            //Act
            Location.EntryId = cateId;
            Location.Purge();

            objectRequest.ObjectId = objectId;
            objectRequest.Purge();
        }

        //[Ignore]
        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new LocationRequest();
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My IdoitClient";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";

            Location.ObjectId = objectId;
            Location.ObjectRequest = categoryRequest;
            cateId = Location.Create();

            //Act: Update the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI 2 description";
            Location.ObjectRequest = categoryRequest;
            Location.Update();

            //Act:Read the Category
            var list = Location.Read();
            Assert.IsTrue(list.Length > 0, "No objects found");
            //Assert
            foreach (LocationResponse v in list)
            {
                Assert.AreEqual("Web GUI 2 description", v.description);
            }
            //Act:Delete the Object
            objectRequest.ObjectId = objectId;
            objectRequest.Delete();
        }

        //[Ignore]
        //Read
        [TestMethod]
        public void CreateReadTest()
        {
            //Arrange
            int cateId, objectId;
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new LocationRequest();
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My IdoitClient";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";

            Location.ObjectId = objectId;
            Location.ObjectRequest = categoryRequest;
            cateId = Location.Create();

            //Act:Read the Category
            var list = Location.Read();
            Assert.IsTrue(list.Length > 0, "No objects found");
            //Assert
            foreach (LocationResponse v in list)
            {
                Assert.AreEqual("Web GUI description", v.description);
            }

            //Act:Delete the Object
            objectRequest.ObjectId = objectId;
            objectRequest.Delete();
        }
    }
}