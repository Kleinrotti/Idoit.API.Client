using Idoit.API.Client.CMDB.Dialog.Request;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Dia = Idoit.API.Client.CMDB.Dialog.IdoitDialogInstance;
using DialogResult = Idoit.API.Client.CMDB.Dialog.Response.DialogResult;

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
            Dia request = new Dia(idoitClient);
            request.Property = Cpu.Type;
            request.Value = "Athlon XP";
            request.Category = IdoitCategory.CPU;

            objID = request.Create();

            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.Property);
            Assert.IsNotNull(request.Value);
            Assert.IsNotNull(request.Category);

            //Act:Delete the Value
            request.Delete(objID);
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            Dia request = new Dia(idoitClient);
            List<DialogResult[]> lists = new List<DialogResult[]>();
            //Act:Read
            request.Property = Global.Category;
            request.Category = IdoitCategory.GLOBAL;
            lists = request.Read();
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
        }

        //Delete
        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            int objID;
            Dia request = new Dia(idoitClient);
            List<DialogResult[]> lists = new List<DialogResult[]>();
            //Act:Create
            request.Property = Access.Type;
            request.Value = "ES23";
            request.Category = IdoitCategory.ACCESS;
            objID = request.Create();
            //Act:Delete the Value
            request.Delete(objID);
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int objID;
            Dia request = new Dia(idoitClient);
            List<DialogResult[]> lists = new List<DialogResult[]>();
            //Act:Create
            request.Property = Port.PortType;
            request.Value = "WLAN23";
            request.Category = IdoitCategory.PORT;
            objID = request.Create();
            //Act:Update
            request.Property = Port.PortType;
            request.Value = "WLAN32";
            request.Category = IdoitCategory.PORT;
            request.Update(objID);
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
            request.Delete(objID);
        }
    }
}