﻿using Microsoft.AspNetCore.Mvc;
using Momo_Pizza.Models;

namespace Momo_Pizza.Controllers
{
    public class AutorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.Where(p => p.Email == email && p.Password==password).FirstOrDefault();
                if (user != null)
                {
                    return Json(true);
                }
            }
            return Json(false); 
        }
    }
}
