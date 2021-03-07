﻿using Idoit.API.Client.CMDB.Object;
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
            var request = new IdoitObjectInstance(idoitClient);
            var lists = new List<IdoitSearchResponse[]>();

            //Act
            request.Type = IdoitObjectTypes.PRINTER;
            request.Title = "Printer 01";
            request.CmdbStatus = IdoitCmdbStatus.DEFECT;
            objID = request.Create();

            //Act:Search
            lists = idoit.Search(request.Title);

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
            Assert.IsNotNull(request.Title);
            Assert.IsNotNull(request.Type);
            Assert.IsNotNull(request.CmdbStatus);

            //Act:Delete the Object
            request.Delete(objID);
        }

        //Constants
        [TestMethod]
        public void ConstantsReadObjectTypesTest()
        {
            //Arrange
            var constants = new IdoitConstantsInstance(idoitClient);
            var lists = new Dictionary<string, string>();

            lists = constants.ReadObjectTypes();
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
            var lists = new Dictionary<string, string>();

            lists = constants.ReadRecordStates();
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
            var lists = new Dictionary<string, string>();

            lists = constants.ReadGlobalCategories();
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
            var lists = new Dictionary<string, string>();

            lists = constants.ReadSpecificCategories();
            Assert.IsTrue(lists.Count > 0);
            foreach (var pair in lists)
            {
                Console.WriteLine(pair.Key, pair.Value);
            }
        }
    }
}