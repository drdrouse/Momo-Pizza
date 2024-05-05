using Momo_Pizza.Controllers;

namespace Testing
{
    [TestClass]
    public class Connection
    {
        [TestMethod]
        public void isConnection()
        {
            var conn = new ConnectionController();
            Assert.IsTrue(conn.isConnected());
        }
    }
}