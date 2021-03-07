using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Obj = Idoit.API.Client.CMDB.Object.IdoitObjectInstance;

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
            var list = new List<ModelResponse[]>();
            var categoryRequest = new ModelRequest();
            Obj objectRequest = new Obj(idoitClient);
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);
            //Act:Create the Object
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Title = " My Client";

            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.manufacturer = 1;
            categoryRequest.description = "Web GUI description";
            cateId = model.Create(objectId, categoryRequest);

            //Assert
            Assert.IsNotNull(cateId);

            //Act: Read the Category
            list = model.Read(objectId);

            //Assert
            foreach (ModelResponse[] row in list)
            {
                foreach (ModelResponse element in row)
                {
                    Assert.IsNotNull(element.title);
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
            var categoryRequest = new ModelRequest();
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Title = " My Client";
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

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
            List<ModelResponse[]> list = new List<ModelResponse[]>();
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new ModelRequest();
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Title = " My Client";
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

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
            list = model.Read(objectId);

            //Assert
            foreach (ModelResponse[] row in list)
            {
                foreach (ModelResponse element in row)
                {
                    Assert.AreEqual("Web GUI 2", element.title);
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
            List<ModelResponse[]> list = new List<ModelResponse[]>();
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new ModelRequest();
            var model = new IdoitSvcInstance<ModelResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Title = " My Client";
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.manufacturer = 1;

            cateId = model.Create(objectId, categoryRequest);

            //Act:Read the Category
            list = model.Read(objectId);

            //Assert
            foreach (ModelResponse[] row in list)
            {
                foreach (ModelResponse element in row)
                {
                    Assert.AreEqual("Web GUI", element.title);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}