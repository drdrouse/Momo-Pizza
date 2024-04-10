using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_User(int pizzaID, int orderID)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Pizza pizza = db.Pizzas.Where(id => id.PizzaId == pizzaID).FirstOrDefault();
                Basket basket = db.Baskets.Where(id => id.BasketId == orderID).FirstOrDefault();
                Order yet_Order = db.Orders.Where(id => id.Id_Pizza == pizzaID).FirstOrDefault();

                Order order = new Order
                {
                    Id_Basket = basket.BasketId,
                    Basket = basket,
                    Id_Pizza = pizza.PizzaId,
                    Pizza = pizza,
                    Count = 1
                };
                if ((order != null) && (yet_Order == null))
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return Json(true);
                }

            }
            return Json(false);
        }
    }
}
