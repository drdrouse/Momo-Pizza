using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;
using NuGet.Configuration;

namespace Momo_Pizza.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Confirm()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Where(id => id.UserId == db.Authorizeds.ToList().FirstOrDefault().User_id).FirstOrDefault();
                Basket basket = db.Baskets.Where(id => id.User_ID == user.UserId).FirstOrDefault();
                CreateHistory(user);
                foreach (Order ord in db.Orders.Where(id => id.Id_Basket == basket.BasketId))
                {
                    AddBoughts(user, ord);
                    if (ord != null)
                    {
                        db.Orders.Remove(ord);
                        db.SaveChanges();
                        
                    }
                }
                
                return Json(true);
            }
        }
        private void AddBoughts(User user, Order ord)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                History history = db.Histories.ToList().LastOrDefault();
                Order order = db.Orders.Where(id => id==ord).FirstOrDefault();
                Pizza pizza = db.Pizzas.Where(id=> id.PizzaId==ord.Id_Pizza).FirstOrDefault();
                Bought bought = new Bought()
                {
                    Id_History = history.HistoryId,
                    History = history,
                    Id_Pizza = pizza.PizzaId,
                    Pizza = pizza,
                    Count = order.Count
                };
                db.Boughts.Add(bought);
                db.SaveChanges();
            }
        }
        private void CreateHistory(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user_ = db.Users.Where(id => id==user).FirstOrDefault();
                History history = new History
                {
                    User_ID = user_.UserId,
                    User = user_
                };
                db.Histories.Add(history);
                db.SaveChanges();
            }
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
                Pizza pizza = db.Pizzas.Where(id => id.PizzaId == delete_order.Id_Pizza).FirstOrDefault();
                if (pizza.Name == "Пицца по твоим правилам")
                {
                    db.Pizzas.Remove(pizza);
                    db.SaveChanges();
                }
                else if (delete_order != null)
                {
                    db.Orders.Remove(delete_order);
                    db.SaveChanges();
                }
            }
        }
    }
}
