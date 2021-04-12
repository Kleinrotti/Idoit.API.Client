using Idoit.API.Client.CMDB.Dialog;
using Idoit.API.Client.Contants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void CreateDeleteTest()
        {
            //Arrange
            int objID;
            var request = new IdoitDialogInstance(idoitClient);
            request.Value = "Athlon XP";
            request.Category = IdoitCategory.CPU;
            request.Property = Cpu.Type;
            objID = request.Create();

            //Assert
            Assert.IsNotNull(objID);
            Assert.IsNotNull(request.Property);
            Assert.IsNotNull(request.Value);
            Assert.IsNotNull(request.Category);

            //Act:Delete the Value
            request.EntryId = objID;
            request.Delete();
        }

        //Read
        [TestMethod]
        public void ReadTest()
        {
            //Arrange
            var request = new IdoitDialogInstance(idoitClient);
            //Act:Read
            request.Category = IdoitCategory.GLOBAL;
            request.Property = Global.Category;
            var lists = request.Read();
            Assert.IsTrue(lists.Length > 0, "No objects found");
            //Assert
            foreach (DialogResult v in lists)
            {
                Assert.IsNotNull(v.id);
                Assert.IsNotNull(v.title);
                Assert.IsNotNull(v.Const);
            }
        }

        //Update
        [TestMethod]
        public void UpdateTest()
        {
            //Arrange
            int objID;
            var request = new IdoitDialogInstance(idoitClient);
            //Act:Create
            request.Value = "WLAN23";
            request.Category = IdoitCategory.PORT;
            request.Property = Port.PortType;
            objID = request.Create();
            //Act:Update
            request.EntryId = objID;
            request.Value = "WLAN32";
            request.Update();

            var result = request.Read();
            Assert.IsTrue(result.Length > 0, "No objects found");
            //Assert
            foreach (DialogResult element in result)
            {
                Assert.IsNotNull(element.id);
                Assert.IsNotNull(element.title);
                Assert.IsNotNull(element.Const);
            }
            //Act:Delete the Value
            request.Delete();
        }
    }
}