using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;
using Idoit.API.Client.Idoit;
using Idoit.API.Client.Idoit.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IdoitUnitTests
{
    //[Ignore]
    [TestClass]
    public class IdoitTest : IdoitTestBase
    {
        public IdoitTest() : base()
        {
        }

        //Version
        [TestMethod]
        public void VersionTest()
        {
            //Arrange
            var idoit = new IdoitInstance(idoitClient);
            var request = new IdoitVersionResponse();
            var logout = new IdoitLogoutResponse();
            var login = new IdoitLoginResponse();

            //login
            login = idoitClient.Login();

            //Version
            request = idoit.Version();

            //Logout
            logout = idoitClient.Logout();

            //Assert
            Assert.IsNotNull(request.version);
            Assert.IsNotNull(request.type);
            Assert.IsNotNull(request.Login.language);
        }

        //Logout
        [TestMethod]
        public void LogoutTest()
        {
            //Arrange
            var request = new IdoitLogoutResponse();

            //Act
            request = idoitClient.Logout();

            //Assert
            Assert.IsNotNull(request.message);
            Assert.IsTrue(request.result);
        }

        //Login
        [TestMethod]
        public void LoginTest()
        {
            //Arrange
            var request = new IdoitLoginResponse();

            //Act
            request = idoitClient.Login();

            //Assert
            Assert.IsTrue(request.result);
            Assert.IsNotNull(request.userId);
        }

        //Search
        [TestMethod]
        public void SearchTest()
        {
            //Arrange
            int objID;
            var idoit = new IdoitInstance(idoitClient);
            var request = new IdoitObjectInstance(idoitClient);

            //Act
            request.CmdbStatus = IdoitCmdbStatus.DEFECT;
            request.Type = IdoitObjectTypes.PRINTER;
            request.Value = "Printer 01";
            objID = request.Create();

            //Act:Search
            var lists = idoit.Search(request.Value);
            Assert.IsTrue(lists.Length > 0, "No objects found");
            //Assert

            foreach (var v in lists)
            {
                Assert.IsNotNull(v.link);
                Assert.IsNotNull(v.key);
                Assert.IsNotNull(v.value);
            }

            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.Value);
            Assert.IsNotNull(request.Type);
            Assert.IsNotNull(request.CmdbStatus);

            //Act:Delete the Object
            request.ObjectId = objID;
            request.Delete();
        }

        //Constants
        [TestMethod]
        public void ConstantsReadObjectTypesTest()
        {
            //Arrange
            var constants = new IdoitConstantsInstance(idoitClient);

            var lists = constants.ReadObjectTypes();
            Assert.IsTrue(lists.Count > 0);
            foreach (var pair in lists)
            {
                Console.WriteLine(pair.Key, pair.Value);
            }
        }

        //Constants
        [TestMethod]
        public void ConstantsReadRecordStatesTest()
        {
            //Arrange
            var constants = new IdoitConstantsInstance(idoitClient);

            var lists = constants.ReadRecordStates();
            Assert.IsTrue(lists.Count > 0);
            foreach (var pair in lists)
            {
                Console.WriteLine(pair.Key, pair.Value);
            }
        }

        //Constants
        [TestMethod]
        public void ConstantsReadCategoriesGlobalTest()
        {
            //Arrange
            var constants = new IdoitConstantsInstance(idoitClient);

            var lists = constants.ReadGlobalCategories();
            Assert.IsTrue(lists.Count > 0);
            foreach (var pair in lists)
            {
                Console.WriteLine(pair.Key, pair.Value);
            }
        }

        //Constants
        [TestMethod]
        public void ConstantsReadCategoriesSpecificTest()
        {
            //Arrange
            var constants = new IdoitConstantsInstance(idoitClient);

            var lists = constants.ReadSpecificCategories();
            Assert.IsTrue(lists.Count > 0);
            foreach (var pair in lists)
            {
                Console.WriteLine(pair.Key, pair.Value);
            }
        }
    }
}