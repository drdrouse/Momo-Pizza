﻿using Microsoft.AspNetCore.Mvc;
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
                foreach (Order ord in db.Orders.Where(id => id.Id_Basket == basket.BasketId))
                {
                    if (ord != null)
                    {
                        db.Orders.Remove(ord);
                        db.SaveChanges();
                        
                    }
                }
                return Json(true);
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
                if (delete_order != null)
                {
                    db.Orders.Remove(delete_order);
                    db.SaveChanges();
                }
            }
        }
    }
}
