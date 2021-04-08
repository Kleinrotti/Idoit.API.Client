using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obj = Idoit.API.Client.CMDB.Object.IdoitObjectInstance;

namespace IdoitUnitTests
{
    [TestClass]
    public class AccessCategoryTest : IdoitTestBase
    {
        public AccessCategoryTest() : base()
        {
        }

        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            int cateId, objectId;
            var categoryRequest = new AccessRequest();
            Obj objectRequest = new Obj(idoitClient);
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);
            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create(IdoitObjectTypes.CLIENT, "My Client");

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            categoryRequest.category_id = cateId;
            var list = access.Read(objectId);

            //Assert
            foreach (AccessResponse v in list)
            {
                Assert.IsNotNull(v.title);
                Assert.IsNotNull(v.id);
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int cateId, objectId;
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create(IdoitObjectTypes.CLIENT, "My Client");

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);

            //Act
            access.Delete(objectId, cateId);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            var list = access.Read(objectId);

            //Assert
            foreach (AccessResponse v in list)
            {
                Assert.IsNotNull(v.title);
                Assert.IsNotNull(v.id);
            }
        }

        //Quickpurge
        [TestMethod]
        public void QuickpurgeTest()
        {
            //Arrange
            int cateId, objectId;
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create(IdoitObjectTypes.CLIENT, "My Client");

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);

            //Act
            access.Quickpurge(objectId, cateId);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create(IdoitObjectTypes.CLIENT, "My Client");

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);

            //Act: Update the Category
            categoryRequest.title = "Web GUI 2";
            categoryRequest.description = "Web GUI 2 description";
            categoryRequest.type = " SE";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            categoryRequest.category_id = cateId;
            access.Update(objectId, categoryRequest);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            var list = access.Read(objectId);

            //Assert
            foreach (AccessResponse v in list)
            {
                Assert.AreEqual("Web GUI 2", v.title);
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int cateId, objectId;
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create(IdoitObjectTypes.CLIENT, "My Client");

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            var list = access.Read(objectId);

            //Assert
            foreach (AccessResponse v in list)
            {
                Assert.AreEqual("Web GUI", v.title);
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}