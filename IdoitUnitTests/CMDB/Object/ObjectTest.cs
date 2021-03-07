using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.CMDB.Object.Response;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdoitUnitTests
{
    [TestClass]
    public class ObjectTest : IdoitTestBase
    {
        public ObjectTest() : base()
        {
        }

        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            int objID;
            var request = new IdoitObjectInstance(idoitClient);
            //Act
            request.Type = IdoitObjectTypes.APPLICATION;
            request.Title = "Chrome";
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objID = request.Create();
            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.Title);
            Assert.IsNotNull(request.Type);
            Assert.IsNotNull(request.CmdbStatus);
            //Act:Delete the Object
            request.Delete(objID);
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int objID;
            var request = new IdoitObjectInstance(idoitClient);
            //Act:Create the Object
            request.Type = IdoitObjectTypes.CLIENT;
            request.Title = " My Client";
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objID = request.Create();
            //Act:Delete the Object
            request.Delete(objID);
            //Assert
            Assert.IsNotNull(objID);
        }

        //Delete and than check if the Object is deleted
        [TestMethod]
        public void DeleteTestCheckIfTheObjectDeleted()
        {
            //Arrange
            int objID;
            var list = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);
            //Act:Create the Object
            request.Type = IdoitObjectTypes.CLIENT;
            request.Title = "Laptop 001";
            request.CmdbStatus = IdoitCmdbStatus.PLANNED;
            objID = request.Create();
            //Act:Delete the Object
            request.Delete(objID);
            //Act:Read the Object
            list = request.Read(objID);
            //Assert
            Assert.AreEqual("4", list.status);
        }

        //Archive
        [TestMethod]
        public void ArchiveTest()
        {
            //Arrange
            int objID;
            var request = new IdoitObjectInstance(idoitClient);
            //Act
            request.Type = IdoitObjectTypes.PRINTER;
            request.Title = "HQ Printer";
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objID = request.Create();
            request.Archive(objID);
            //Assert
            Assert.IsNotNull(objID);
        }

        //Archive and than check if the Object is archied
        [TestMethod]
        public void ArchiveTestCheckIfTheObjectArchived()
        {
            //Arrange
            int objID;
            var list = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);

            //Act:Create the Object
            request.Type = IdoitObjectTypes.ROUTER;
            request.Title = "HQ Gateway";
            request.CmdbStatus = IdoitCmdbStatus.DEFECT;
            objID = request.Create();

            //Act:Archive the Object
            request.Archive(objID);

            //Act:Read the Object
            list = request.Read(objID);

            //Assert
            Assert.AreEqual("3", list.status);
        }

        //Purge
        [TestMethod]
        public void PurgeTest()
        {
            //Arrange
            int objID;
            var request = new IdoitObjectInstance(idoitClient);

            //Act:Create the Object
            request.Type = IdoitObjectTypes.MONITOR;
            request.Title = "TFT 001";
            request.CmdbStatus = IdoitCmdbStatus.STORED;
            objID = request.Create();

            //Act:Purge the Object
            request.Purge(objID);

            //Assert
            Assert.IsNotNull(objID);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int objID;
            var list = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);
            //Act:Create the Object
            request.Type = IdoitObjectTypes.SERVER;
            request.Title = " Switch Colo A001 02";
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objID = request.Create();
            //Act:Update the Object
            request.Title = "Switch Colo A001 01";
            request.Update(objID);
            //Act:Read the Object
            list = request.Read(objID);
            //Assert
            Assert.AreEqual("Switch Colo A001 01", list.title);
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int objID;
            var list = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);
            //Act:Create the Object
            request.Type = IdoitObjectTypes.SERVER;
            request.Title = "Ceph Storage Pod A001 01";
            request.CmdbStatus = IdoitCmdbStatus.PLANNED;
            objID = request.Create();
            //Act:Read the Object
            list = request.Read(objID);
            //Assert
            Assert.AreEqual(objID, list.id);
            Assert.AreEqual("Ceph Storage Pod A001 01", list.title);
            Assert.IsNotNull(list.title);
            Assert.IsNotNull(list.cmdbStatus);
            //Act:Delete the Object
            request.Purge(objID);
        }
    }
}