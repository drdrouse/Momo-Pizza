using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void UpdateCountPizza_Plus(int orderID)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Order update_order = db.Orders.Where(id => id.OrderId == orderID).FirstOrDefault();
                if ((update_order != null) && (update_order.Count<99))
                {
                    update_order.Count += 1;
                    db.SaveChanges();
                }
            }
        }

        [HttpPost]
        public void UpdateCountPizza_Minus(int orderID)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Order update_order = db.Orders.Where(id => id.OrderId == orderID).FirstOrDefault();
                if ((update_order != null) && (update_order.Count > 1))
                {
                    update_order.Count -= 1;
                    db.SaveChanges();
                }
            }
        }

        [HttpPost]
        public void Delete_Order(int orderID)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Order delete_order = db.Orders.Where(id => id.OrderId == orderID).FirstOrDefault();
                if (delete_order != null)
                {
                    db.Orders.Remove(delete_order);
                    db.SaveChanges();
                }
            }
        }
    }
}
