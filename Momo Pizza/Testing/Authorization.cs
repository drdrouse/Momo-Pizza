using Momo_Pizza.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestClass]
    public class Authorization
    {
        [TestMethod]
        public void Correct_Authorization()
        {
            var auth = new AutorizationController();
            Assert.IsTrue(auth.isAuthorize("coh-abozobe75@yahoo.com", "MasterNagibator69"));
        }
        
        [TestMethod]
        public void Incorrect_Password_Authorization()
        {
            var auth = new AutorizationController();
            Assert.IsFalse(auth.isAuthorize("coh-abozobe75@yahoo.com", "qwerty"));
        }
        
        [TestMethod]
        public void Incorrect_Login_Authorization()
        {
            var auth = new AutorizationController();
            Assert.IsFalse(auth.isAuthorize("lewofe9622@storesr.com", "MasterNagibator69"));
        }
        
        [TestMethod]
        public void Incorrect_Authorization()
        {
            var auth = new AutorizationController();
            Assert.IsFalse(auth.isAuthorize("abozobe76@yahoo.com", "MasterNagibaor69"));
        }

    }
}
