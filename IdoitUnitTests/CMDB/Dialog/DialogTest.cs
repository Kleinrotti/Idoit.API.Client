using Idoit.API.Client.CMDB.Dialog;
using Idoit.API.Client.CMDB.Dialog.Request;
using Idoit.API.Client.CMDB.Dialog.Response;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IdoitUnitTests
{
    [TestClass]
    public class DialogTest : IdoitTestBase
    {
        public DialogTest() : base()
        {
        }

        //Create
        [TestMethod]
        public void CreateTest()
        {
            //Arrange
            int objID;
            var request = new IdoitDialogInstance(idoitClient);

            objID = request.Create("Athlon XP", Cpu.Type, IdoitCategory.CPU);

            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.Property);
            Assert.IsNotNull(request.Value);
            Assert.IsNotNull(request.Category);

            //Act:Delete the Value
            request.Delete(objID, Cpu.Type, IdoitCategory.CPU);
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            var request = new IdoitDialogInstance(idoitClient);
            //Act:Read
            var lists = request.Read(Global.Category, IdoitCategory.GLOBAL);
            //Assert
            foreach (DialogResult v in lists)
            {
                Assert.IsNotNull(v.id);
                Assert.IsNotNull(v.title);
                Assert.IsNotNull(v.Const);
            }
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int objID;
            var request = new IdoitDialogInstance(idoitClient);
            var lists = new List<DialogResult[]>();
            //Act:Create
            objID = request.Create("ES23", Access.Type, IdoitCategory.ACCESS);
            //Act:Delete the Value
            request.Delete(objID, Access.Type, IdoitCategory.ACCESS);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int objID;
            var request = new IdoitDialogInstance(idoitClient);
            var lists = new List<DialogResult[]>();
            //Act:Create
            objID = request.Create("WLAN23", Port.PortType, IdoitCategory.PORT);
            //Act:Update
            request.Update(objID, "WLAN32", Port.PortType, IdoitCategory.PORT);
            //Assert
            foreach (DialogResult[] row in lists)
            {
                foreach (DialogResult element in row)
                {
                    Assert.IsNotNull(element.id);
                    Assert.IsNotNull(element.title);
                    Assert.IsNotNull(element.Const);
                }
            }
            //Act:Delete the Value
            request.Delete(objID, Port.PortType, IdoitCategory.PORT);
        }
    }
}