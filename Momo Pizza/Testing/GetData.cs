using Momo_Pizza.Controllers;

namespace Testing
{
    [TestClass]
    public class GetData
    {
        [TestMethod]
        public void AddData()
        {
            var add = new GetDataController();
            Assert.IsTrue(add.AddData("Неаполитанское тесто", "Пшеничная мука", 456.6, 55));
        }

        [TestMethod]
        public void ChangeData()
        {
            var chan = new GetDataController();
            Assert.IsTrue(chan.ChangeData("Неаполитанское тесто", 101));
        }

        [TestMethod]
        public void DeleteData()
        {
            var delete = new GetDataController();
            Assert.IsTrue(delete.DeleteData("Неаполитанское тесто"));
        }
    }
}
