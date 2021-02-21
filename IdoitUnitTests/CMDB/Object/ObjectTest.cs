using Idoit.API.Client.CMDB.Object.Response;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obj = Idoit.API.Client.CMDB.Object.IdoitObject;

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
            Obj request = new Obj(idoitClient);
            //Act
            request.type = IdoitObjectTypes.APPLICATION;
            request.title = "Chrome";
            request.cmdbStatus = IdoitCmdbStatus.INOPERATION;
            objID = request.Create();
            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.title);
            Assert.IsNotNull(request.type);
            Assert.IsNotNull(request.cmdbStatus);
            //Act:Delete the Object
            request.Delete(objID);
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int objID;
            Obj request = new Obj(idoitClient);
            //Act:Create the Object
            request.type = IdoitObjectTypes.CLIENT;
            request.title = " My Client";
            request.cmdbStatus = IdoitCmdbStatus.INOPERATION;
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
            Result list = new Result();
            Obj request = new Obj(idoitClient);
            //Act:Create the Object
            request.type = IdoitObjectTypes.CLIENT;
            request.title = "Laptop 001";
            request.cmdbStatus = IdoitCmdbStatus.PLANNED;
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
            Obj request = new Obj(idoitClient);
            //Act
            request.type = IdoitObjectTypes.PRINTER;
            request.title = "HQ Printer";
            request.cmdbStatus = IdoitCmdbStatus.INOPERATION;
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
            Result list = new Result();
            Obj request = new Obj(idoitClient);

            //Act:Create the Object
            request.type = IdoitObjectTypes.ROUTER;
            request.title = "HQ Gateway";
            request.cmdbStatus = IdoitCmdbStatus.DEFECT;
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
            Obj request = new Obj(idoitClient);

            //Act:Create the Object
            request.type = IdoitObjectTypes.MONITOR;
            request.title = "TFT 001";
            request.cmdbStatus = IdoitCmdbStatus.STORED;
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
            Result list = new Result();
            Obj request = new Obj(idoitClient);
            //Act:Create the Object
            request.type = IdoitObjectTypes.SERVER;
            request.title = " Switch Colo A001 02";
            request.cmdbStatus = IdoitCmdbStatus.INOPERATION;
            objID = request.Create();
            //Act:Update the Object
            request.title = "Switch Colo A001 01";
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
            Result list = new Result();
            Obj request = new Obj(idoitClient);
            //Act:Create the Object
            request.type = IdoitObjectTypes.SERVER;
            request.title = "Ceph Storage Pod A001 01";
            request.cmdbStatus = IdoitCmdbStatus.PLANNED;
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