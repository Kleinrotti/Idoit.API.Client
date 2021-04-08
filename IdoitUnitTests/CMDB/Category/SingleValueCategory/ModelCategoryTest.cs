using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdoitUnitTests
{
    //[Ignore]
    [TestClass]
    public class ModelCategoryTest : IdoitTestBase
    {
        public ModelCategoryTest() : base()
        {
        }

        //[Ignore]
        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            int cateId, objectId;
            var categoryRequest = new ModelRequest();
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);
            //Act:Create the Object

            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create(IdoitObjectTypes.CLIENT, "My Client");

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.manufacturer = 1;
            categoryRequest.description = "Web GUI description";
            cateId = model.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            var list = model.Read(objectId);

            //Assert
            foreach (ModelResponse v in list)
            {
                Assert.IsNotNull(v.title);
                Assert.IsNotNull(v.id);
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
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new ModelRequest();
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create(IdoitObjectTypes.CLIENT, "My Client");

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;
            cateId = model.Create(objectId, categoryRequest);

            //Act
            model.Quickpurge(objectId, cateId);
        }

        //[Ignore]
        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int cateId, objectId;
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new ModelRequest();
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create(IdoitObjectTypes.CLIENT, "My Client");

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;

            cateId = model.Create(objectId, categoryRequest);

            //Act: Update the Category
            categoryRequest.title = "Web GUI 2";
            categoryRequest.description = "Web GUI 2 description";

            model.Update(objectId, categoryRequest);

            //Act:Read the Category
            var list = model.Read(objectId);

            //Assert
            foreach (ModelResponse v in list)
            {
                Assert.AreEqual("Web GUI 2", v.title.title);
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
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new ModelRequest();
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create(IdoitObjectTypes.CLIENT, "My Client");

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;

            cateId = model.Create(objectId, categoryRequest);

            //Act:Read the Category
            var list = model.Read(objectId);

            //Assert
            foreach (ModelResponse v in list)
            {
                Assert.AreEqual("Web GUI", v.title.title);
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}