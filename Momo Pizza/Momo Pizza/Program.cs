using Microsoft.EntityFrameworkCore;
using Momo_Pizza.Models;
using System.Diagnostics;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//using (ApplicationContext db = new ApplicationContext())
//{
    
//     Basket basket1 = db.Baskets.Where(id => id.BasketId == 1).FirstOrDefault();
//     Basket basket2 = db.Baskets.Where(id => id.BasketId == 2).FirstOrDefault();
//     Pizza pizza18 = db.Pizzas.Where(id => id.PizzaId == 18).FirstOrDefault();
//     Pizza pizza19 = db.Pizzas.Where(id => id.PizzaId == 19).FirstOrDefault();
     
    
//    Order order1 = new Order
//    { 
//        Id_Basket = basket1.BasketId,
//        Basket = basket1,
//        PizzaId = pizza18.PizzaId,
//        Pizza = pizza18
//    };
//    Order order2 = new Order
//    {
//        Id_Basket = basket1.BasketId,
//        Basket = basket1,
//        PizzaId = pizza19.PizzaId,
//        Pizza = pizza19
//    };
//    Order order3 = new Order
//    {
//        Id_Basket = basket2.BasketId,
//        Basket = basket2,
//        PizzaId = pizza18.PizzaId,
//        Pizza = pizza18
//    };


//    // Добавление
//    db.Orders.AddRange(order1, order2, order3);
//    db.SaveChanges();
//}

app.Run();


