using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Obj = Idoit.API.Client.CMDB.Object.IdoitObject;

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
            var list = new List<AccessResponse[]>();
            var categoryRequest = new AccessRequest();
            Obj objectRequest = new Obj(idoitClient);
            var access = new MultiValueCategory<AccessResponse>(idoitClient);
            //Act:Create the Object
            objectRequest.type = IdoitObjectTypes.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

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
            list = access.Read(objectId);

            //Assert
            foreach (AccessResponse[] row in list)
            {
                foreach (AccessResponse element in row)
                {
                    Assert.IsNotNull(element.title);
                    Assert.IsNotNull(element.id);
                }
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
            List<AccessResponse[]> list = new List<AccessResponse[]>();
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new MultiValueCategory<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.type = IdoitObjectTypes.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

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
            list = access.Read(objectId);

            //Assert
            foreach (AccessResponse[] row in list)
            {
                foreach (AccessResponse element in row)
                {
                    Assert.IsNotNull(element.title);
                    Assert.IsNotNull(element.id);
                }
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
            var access = new MultiValueCategory<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.type = IdoitObjectTypes.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

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
            List<AccessResponse[]> list = new List<AccessResponse[]>();
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new MultiValueCategory<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.type = IdoitObjectTypes.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

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
            list = access.Read(objectId);

            //Assert
            foreach (AccessResponse[] row in list)
            {
                foreach (AccessResponse element in row)
                {
                    Assert.AreEqual("Web GUI 2", element.title);
                }
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
            List<AccessResponse[]> list = new List<AccessResponse[]>();
            Obj objectRequest = new Obj(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new MultiValueCategory<AccessResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.type = IdoitObjectTypes.CLIENT;
            objectRequest.title = " My Client";
            objectRequest.cmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            cateId = access.Create(objectId, categoryRequest);

            //Act:Read the Category
            categoryRequest.category_id = cateId;
            list = access.Read(objectId);

            //Assert
            foreach (AccessResponse[] row in list)
            {
                foreach (AccessResponse element in row)
                {
                    Assert.AreEqual("Web GUI", element.title);
                }
            }

            //Act:Delete the Object
            objectRequest.Delete(objectId);
        }
    }
}