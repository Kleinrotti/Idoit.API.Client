using Idoit.API.Client.CMDB.Object;
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

        //Delete and than check if the Object is deleted
        [TestMethod]
        public void DeleteTestCheckIfTheObjectDeleted()
        {
            //Arrange
            int objID;
            var result = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);
            //Act:Create the Object
            request.CmdbStatus = IdoitCmdbStatus.PLANNED;
            request.Type = IdoitObjectTypes.CLIENT;
            request.Value = "Laptop 001";
            objID = request.Create();
            Assert.IsNotNull(objID);
            //Act:Delete the Object
            request.ObjectId = objID;
            request.Delete();
            //Act:Read the Object
            result = request.Read();
            //Assert
            Assert.AreEqual(IdoitStatusTypes.Deleted, result.status);
        }

        //Archive and than check if the Object is archied
        [TestMethod]
        public void ArchiveTestCheckIfTheObjectArchived()
        {
            //Arrange
            int objID;
            var result = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);

            //Act:Create the Object
            request.CmdbStatus = IdoitCmdbStatus.DEFECT;
            request.Type = IdoitObjectTypes.ROUTER;
            request.Value = "HQ Gateway";
            objID = request.Create();
            Assert.IsNotNull(objID);
            //Act:Archive the Object
            request.ObjectId = objID;
            request.Archive();

            //Act:Read the Object
            result = request.Read();

            //Assert
            Assert.AreEqual(IdoitStatusTypes.Archived, result.status);
        }

        //Purge
        [TestMethod]
        public void PurgeTest()
        {
            //Arrange
            int objID;
            var request = new IdoitObjectInstance(idoitClient);

            //Act:Create the Object
            request.CmdbStatus = IdoitCmdbStatus.STORED;
            request.Type = IdoitObjectTypes.MONITOR;
            request.Value = "TFT 001";
            objID = request.Create();
            request.ObjectId = objID;
            //Act:Purge the Object
            request.Purge();

            //Assert
            Assert.IsNotNull(objID);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int objID;
            var result = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);
            //Act:Create the Object
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            request.Type = IdoitObjectTypes.SERVER;
            request.Value = "Switch Colo A001 02";
            objID = request.Create();
            //Act:Update the Object
            request.ObjectId = objID;
            request.Value = "Switch Colo A001 01";
            request.Update();
            //Act:Read the Object
            result = request.Read();
            //Assert
            Assert.AreEqual("Switch Colo A001 01", result.title);
            request.Delete();
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            int objID;
            var result = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);
            //Act:Create the Object
            request.CmdbStatus = IdoitCmdbStatus.PLANNED;
            request.Type = IdoitObjectTypes.SERVER;
            request.Value = "Ceph Storage Pod A001 01";
            objID = request.Create();
            //Act:Read the Object
            request.ObjectId = objID;
            result = request.Read();
            //Assert
            Assert.AreEqual(objID, result.id);
            Assert.AreEqual("Ceph Storage Pod A001 01", result.title);
            Assert.IsNotNull(result.title);
            Assert.IsNotNull(result.cmdbStatus);
            //Act:Delete the Object
            request.Delete();
        }
    }
}