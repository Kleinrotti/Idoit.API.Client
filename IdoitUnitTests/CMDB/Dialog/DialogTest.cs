using Idoit.API.Client.CMDB.Dialog.Request;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Dia = Idoit.API.Client.CMDB.Dialog.Dialog;
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
            request.property = Cpu.Type;
            request.value = "Athlon XP";
            request.category = IdoitCategory.CPU;

            objID = request.Create();

            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.property);
            Assert.IsNotNull(request.value);
            Assert.IsNotNull(request.category);

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
            request.property = Global.Category;
            request.category = IdoitCategory.GLOBAL;
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
            request.property = Access.Type;
            request.value = "ES23";
            request.category = IdoitCategory.ACCESS;
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
            request.property = Port.PortType;
            request.value = "WLAN23";
            request.category = IdoitCategory.PORT;
            objID = request.Create();
            //Act:Update
            request.property = Port.PortType;
            request.value = "WLAN32";
            request.category = IdoitCategory.PORT;
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