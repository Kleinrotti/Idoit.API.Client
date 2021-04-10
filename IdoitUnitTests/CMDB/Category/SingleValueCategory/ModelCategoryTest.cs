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
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;
            model.ObjectId = objectId;
            model.ObjectRequest = categoryRequest;
            cateId = model.Create();

            //Act
            model.EntryId = cateId;
            model.Purge();

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
            var categoryRequest = new ModelRequest();
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;

            model.ObjectId = objectId;
            model.ObjectRequest = categoryRequest;
            cateId = model.Create();

            //Act: Update the Category
            categoryRequest.title = "Web GUI 2";
            categoryRequest.description = "Web GUI 2 description";
            model.ObjectRequest = categoryRequest;
            model.Update();

            //Act:Read the Category
            var list = model.Read();
            Assert.IsTrue(list.Length > 0, "No objects found");
            //Assert
            foreach (ModelResponse v in list)
            {
                Assert.AreEqual("Web GUI 2", v.title.title);
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
            var categoryRequest = new ModelRequest();
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;

            model.ObjectId = objectId;
            model.ObjectRequest = categoryRequest;
            cateId = model.Create();

            //Act:Read the Category
            var list = model.Read();
            Assert.IsTrue(list.Length > 0, "No objects found");
            //Assert
            foreach (ModelResponse v in list)
            {
                Assert.AreEqual("Web GUI", v.title.title);
            }

            //Act:Delete the Object
            objectRequest.ObjectId = objectId;
            objectRequest.Delete();
        }
    }
}