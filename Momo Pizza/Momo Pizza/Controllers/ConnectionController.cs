using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class ConnectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public bool isConnected()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool isAvalaible = db.Database.CanConnect();
                if (isAvalaible) return true;
                else return false;
            }
        }
    }
}
