using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;
using Idoit.API.Client.Idoit;
using Idoit.API.Client.Idoit.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            login = idoit.Login();

            //Version
            idoitClient.sessionId = login.sessionId;
            request = idoit.Version();

            //Logout
            logout = idoit.Logout();

            //Assert
            Assert.IsNotNull(request.version);
            Assert.IsNotNull(request.type);
            Assert.IsNotNull(request.login.language);
        }

        //Logout
        [TestMethod]
        public void LogoutTest()
        {
            //Arrange
            var idoit = new IdoitInstance(idoitClient);
            var request = new IdoitLogoutResponse();

            //Act
            request = idoit.Logout();

            //Assert
            Assert.IsNotNull(request.message);
            Assert.IsTrue(request.result);
        }

        //Login
        [TestMethod]
        public void LoginTest()
        {
            //Arrange
            var idoit = new IdoitInstance(idoitClient);
            var request = new IdoitLoginResponse();

            //Act
            request = idoit.Login();

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
            var request = new IdoitObject(idoitClient);
            var lists = new List<IdoitSearchResponse[]>();

            //Act
            request.type = IdoitObjectTypes.PRINTER;
            request.title = "Printer 01";
            request.cmdbStatus = IdoitCmdbStatus.DEFECT;
            objID = request.Create();

            //Act:Search
            lists = idoit.Search(request.title);

            //Assert
            foreach (IdoitSearchResponse[] row in lists)
            {
                foreach (IdoitSearchResponse element in row)
                {
                    Assert.IsNotNull(element.link);
                    Assert.IsNotNull(element.key);
                    Assert.IsNotNull(element.value);
                }
            }
            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.title);
            Assert.IsNotNull(request.type);
            Assert.IsNotNull(request.cmdbStatus);

            //Act:Delete the Object
            request.Delete(objID);
        }

        //Constants
        [TestMethod]
        public void ConstantsReadObjectTypesTest()
        {
            //Arrange
            Constants constants = new Constants(idoitClient);
            Dictionary<string, string> lists = new Dictionary<string, string>();

            lists = constants.ReadObjectTypes();

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
            Constants constants = new Constants(idoitClient);
            Dictionary<string, string> lists = new Dictionary<string, string>();

            lists = constants.ReadRecordStates();

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
            Constants constants = new Constants(idoitClient);
            Dictionary<string, string> lists = new Dictionary<string, string>();

            lists = constants.ReadGlobalCategories();

            foreach (var pair in lists)
            {
                //Assert
                Assert.IsNotNull(pair.Key);
                Assert.IsNotNull(pair.Value);
            }
        }

        //Constants
        [TestMethod]
        public void ConstantsReadCategoriesSpecificTest()
        {
            //Arrange
            Constants constants = new Constants(idoitClient);
            Dictionary<string, string> lists = new Dictionary<string, string>();

            lists = constants.ReadSpecificCategories();

            foreach (var pair in lists)
            {
                //Assert
                Assert.IsNotNull(pair.Key);
                Assert.IsNotNull(pair.Value);
            }
        }
    }
}