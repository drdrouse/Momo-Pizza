using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Confirm(int id_history)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Where(id => id.UserId == db.Authorizeds.ToList().FirstOrDefault().User_id).FirstOrDefault();
                Basket basket = db.Baskets.Where(id => id.User_ID == user.UserId).FirstOrDefault();
                foreach (Bought boug in db.Boughts.Where(his_id => his_id.Id_History == id_history))
                {
                    Pizza pizza = db.Pizzas.Where(id => id.PizzaId == boug.Id_Pizza).FirstOrDefault();
                    Order order = new Order()
                    {
                        Id_Basket = basket.BasketId,
                        Basket = basket,
                        Id_Pizza = pizza.PizzaId,
                        Pizza = pizza,
                        Count = boug.Count
                    };

                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                return Json(true);
            }
        }
    }
}
