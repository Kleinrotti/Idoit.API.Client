using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdoitUnitTests
{
    [TestClass]
    public class AccessCategoryTest : IdoitTestBase
    {
        public AccessCategoryTest() : base()
        {
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int cateId, objectId;
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            access.ObjectId = objectId;
            access.ObjectRequest = categoryRequest;
            cateId = access.Create();

            //Act:Read the Category

            var list = access.Read();
            Assert.IsFalse(list.Length == 0, "No objects found");
            //Assert
            foreach (AccessResponse v in list)
            {
                Assert.IsNotNull(v.title);
                Assert.IsNotNull(v.id);
            }
            access.CateId = cateId;
            access.Delete();
            objectRequest.ObjectId = objectId;
            objectRequest.Delete();
        }

        //Quickpurge
        [TestMethod]
        public void QuickpurgeTest()
        {
            //Arrange
            int cateId, objectId;
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            access.ObjectId = objectId;
            access.ObjectRequest = categoryRequest;
            cateId = access.Create();

            //Act
            access.CateId = cateId;
            access.Purge();

            objectRequest.ObjectId = objectId;
            objectRequest.Purge();
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            access.ObjectId = objectId;
            access.ObjectRequest = categoryRequest;
            cateId = access.Create();

            //Act: Update the Category
            categoryRequest.title = "Web GUI 2";
            categoryRequest.description = "Web GUI 2 description";
            categoryRequest.type = " SE";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            categoryRequest.category_id = cateId;
            //categoryRequest.category_id = cateId;
            access.ObjectRequest = categoryRequest;
            access.Update();

            //Act:Read the Category
            var list = access.Read();
            Assert.IsTrue(list.Length > 0, "No objects found");
            //Assert
            foreach (AccessResponse v in list)
            {
                Assert.AreEqual("Web GUI 2", v.title);
            }

            //Act:Delete the Object
            objectRequest.ObjectId = objectId;
            objectRequest.Delete();
        }

        //Read
        [TestMethod]
        public void CreateReadTest()
        {
            //Arrange
            int cateId, objectId;
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            access.ObjectId = objectId;
            access.ObjectRequest = categoryRequest;
            cateId = access.Create();

            //Act:Read the Category
            var list = access.Read();
            Assert.IsTrue(list.Length > 0, "No objects found");
            //Assert
            foreach (AccessResponse v in list)
            {
                Assert.AreEqual("Web GUI", v.title);
            }

            //Act:Delete the Object
            objectRequest.ObjectId = objectId;
            objectRequest.Delete();
        }
    }
}