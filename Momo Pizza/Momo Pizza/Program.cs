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
using (ApplicationContext db = new ApplicationContext())
{
    User user1 = new User();
    User user2 = new User();
    if (!db.Users.Any())
    {
        user1 = new User
        {
            Phone = "+7 (938) 834-30-82",
            Email = "coh-abozobe75@yahoo.com",
            Password = "MasterNagibator69",
            UserName = "��������� ����"
        };
        user2 = new User
        {
            Phone = "+7 (910) 890-73-93",
            Email = "lewofe9622@storesr.com",
            Password = "qwerty",
            UserName = "���� �������"
        };
        db.Users.AddRange(user1, user2);
        db.SaveChanges();
    }
    //----------------------------------------------------
    
    Basket basket1 = new Basket();
    Basket basket2 = new Basket();
    if (!db.Baskets.Any())
    {
        User user1_ = db.Users.Where(id => id == user1).FirstOrDefault();
        User user2_ = db.Users.Where(id => id == user2).FirstOrDefault();
        basket1 = new Basket
        {
            User_ID = user1_.UserId,
            User = user1_
        };
        basket2 = new Basket
        {
            User_ID = user2_.UserId,
            User = user2_
        };
        db.Baskets.AddRange(basket1, basket2);
        db.SaveChanges();
    }
    //----------------------------------------------------
    Sauce sauce1 = new Sauce();
    Sauce sauce2 = new Sauce();
    Sauce sauce3 = new Sauce();
    Sauce sauce4 = new Sauce();
    Sauce sauce5 = new Sauce();
    Sauce sauce6 = new Sauce();
    Sauce sauce7 = new Sauce();
    if (!db.Sauces.Any())
    {
        sauce1 = new Sauce
        {
            Name_Sauce = "������ ����",
            Type_Sauce = "��������",
            Description = "������ �����: ������, ���������, ������������!",
            Calories = 215,
            Price = 45
        };
        sauce2 = new Sauce
        {
            Name_Sauce = "���� �����",
            Type_Sauce = "��������",
            Description = "��������� ������ �� ����� �����!",
            Calories = 168.9,
            Price = 60
        };
        sauce3 = new Sauce
        {
            Name_Sauce = "��������� ����",
            Type_Sauce = "��������",
            Description = "������ ������ � ������� ������ �������� �����!",
            Calories = 371,
            Price = 45
        };
        sauce4 = new Sauce
        {
            Name_Sauce = "���� �������",
            Type_Sauce = "��������",
            Description = "������, ���������, ������������!",
            Calories = 99,
            Price = 45
        };
        sauce5 = new Sauce
        {
            Name_Sauce = "�������� ����",
            Type_Sauce = "��������",
            Description = "������� ����� ������ ������",
            Calories = 134,
            Price = 50
        };
        sauce6 = new Sauce
        {
            Name_Sauce = "���� ��������",
            Type_Sauce = "��������",
            Description = "���������, ������, ������!",
            Calories = 172,
            Price = 80
        };
        sauce7 = new Sauce
        {
            Name_Sauce = "��� �����",
            Type_Sauce = "-",
            Description = "-",
            Calories = 0,
            Price = 0
        };
        db.AddRange(sauce1, sauce2, sauce3, sauce4, sauce5, sauce6, sauce7);
        db.SaveChanges();
    }
    //----------------------------------------------------
    Dough dough1 = new Dough();
    Dough dough2 = new Dough();
    Dough dough3 = new Dough();
    Dough dough4 = new Dough();
    Dough dough5 = new Dough();
    Dough dough6 = new Dough();
    Dough dough7 = new Dough();

    if (!db.Doughs.Any())
    {
        dough1 = new Dough
        {
            Name = "������������ �����",
            Type_flour = "��������� ����",
            Calories = 331.7,
            Price = 89
        };
        dough2 = new Dough
        {
            Name = "��������� �����",
            Type_flour = "��������� ����",
            Calories = 221.7,
            Price = 50
        };
        dough3 = new Dough
        {
            Name = "������������� �����",
            Type_flour = "��������� ����",
            Calories = 251.8,
            Price = 60
        };
        dough4 = new Dough
        {
            Name = "����������� �����",
            Type_flour = "�������������� ����",
            Calories = 121.9,
            Price = 120
        };
        dough5 = new Dough
        {
            Name = "���-������� �����",
            Type_flour = "���������� ����",
            Calories = 354,
            Price = 99
        };
        dough6 = new Dough
        {
            Name = "������ �����",
            Type_flour = "�������������� ����",
            Calories = 250.4,
            Price = 40
        };
        dough7 = new Dough
        {
            Name = "�������� �����",
            Type_flour = "��������� ����",
            Calories = 189.7,
            Price = 64
        };
        db.Doughs.AddRange(dough1, dough2, dough3, dough4, dough5, dough6, dough7);
        db.SaveChanges();
    }
    //----------------------------------------------------
    Pizza pizza1 = new Pizza();
    Pizza pizza2 = new Pizza();
    Pizza pizza3 = new Pizza();
    Pizza pizza4 = new Pizza();
    Pizza pizza5 = new Pizza();
    Pizza pizza6 = new Pizza();

    if (!db.Pizzas.Any())
    {
        Dough dough1_ = db.Doughs.Where(id => id == dough1).FirstOrDefault();
        Dough dough2_ = db.Doughs.Where(id => id == dough2).FirstOrDefault();
        Dough dough3_ = db.Doughs.Where(id => id == dough3).FirstOrDefault();
        Dough dough4_ = db.Doughs.Where(id => id == dough4).FirstOrDefault();
        Dough dough5_ = db.Doughs.Where(id => id == dough5).FirstOrDefault();
        Dough dough7_ = db.Doughs.Where(id => id == dough7).FirstOrDefault();

        Sauce sauce1_ = db.Sauces.Where(id => id == sauce1).FirstOrDefault();
        Sauce sauce2_ = db.Sauces.Where(id => id == sauce2).FirstOrDefault();
        Sauce sauce4_ = db.Sauces.Where(id => id == sauce4).FirstOrDefault();
        Sauce sauce5_ = db.Sauces.Where(id => id == sauce5).FirstOrDefault();
        pizza1 = new Pizza
        {
            Name = "���������",
            Diameter = 30,
            Price = 579,
            Photo = "Pepperoni.jpg",
            Description = "��������� � ��������, ������� �� ���� ����! ��������� �����, ��������� �������� ����, ��������� �������� ��������� � ������� ��������� � ��� �����, �� ������� ���������� ����������. ������������ ����, ������� ������ �������� � ������ ��������� ������� ��� ����� ��������. ������ ��������� � �� ����������!",
            ID_Dough = dough1_.DoughId,
            Dough = dough1_,
            ID_Sauce = sauce1_.SauceId,
            Sauces = sauce1_
        };
        pizza2 = new Pizza
        {
            Name = "������",
            Diameter = 25,
            Price = 279,
            Photo = "Cheasy.jpg",
            Description = "������, ���������, � ������� ���������� � ���������� ������ � ����� ������ ������� ��� ��������� ��������� �����. ��������� ����� ���� �� ���, ��������� ������� ����� �����, � ������ ������� ����� ������������ ��������. ������ ����� ������ � ������� ���� ������� � ���� �����������!",
            ID_Dough = dough2_.DoughId,
            Dough = dough2_,
            ID_Sauce = sauce1_.SauceId,
            Sauces = sauce1_
        };
        pizza3 = new Pizza
        {
            Name = "���������� � �����",
            Diameter = 35,
            Price = 999,
            Photo = "Mortadella.jpg",
            Description = "��������� ���������� �����, ��������� ����������, ������� ��������� � ���������� ����� ������� ������������ ����, ������� ��������� ���� �� ��������� ����� ������. ������ ����� \"���������� � �����\" � ������� ���� ������� � ���� ����������������� �����������",
            ID_Dough = dough5_.DoughId,
            Dough = dough5_,
            ID_Sauce = sauce2_.SauceId,
            Sauces = sauce2_
        };
        pizza4 = new Pizza
        {
            Name = "���������",
            Diameter = 30,
            Price = 759,
            Photo = "Hawai.jpg",
            Description = "���������: ������� ����������� �� ����� �������! ������� �������, ��������� �������, ������� ��������� � ��������� ����� � ����� \"���������\" ������� ��� ���, ��� ����� ������������� ��������� ������. ������ ����� \"���������\" � ������� ���� ������� ���!!",
            ID_Dough = dough7_.DoughId,
            Dough = dough7_,
            ID_Sauce = sauce1_.SauceId,
            Sauces = sauce1_
        };
        pizza5 = new Pizza
        {
            Name = "������� �������",
            Diameter = 25,
            Price = 379,
            Photo = "Chiken.jpg",
            Description = "�������� �������: �����, �� ������� �� ����������! ��������� ���������� �������� ����, ���������� ����� �������, ������� ��������� � ���������� ����� ������� ������������ ����, ������� ���������� ���� �����. ��������� ������ � ��������� ������, ������� �������� �������!",
            ID_Dough = dough4_.DoughId,
            Dough = dough4_,
            ID_Sauce = sauce4_.SauceId,
            Sauces = sauce4_
        };
        pizza6 = new Pizza
        {
            Name = "������ ���� � ���������� ����������",
            Diameter = 35,
            Price = 1199,
            Photo = "Meat.jpg",
            Description = "������ ���� � ���������� ����������: ����� ��� ��������� ��������! ��������� ��������� ��������, �������, ��������� ���������, ������� ��������� � ��������� ����� � ����� \"������ ����\" ������� ��� ���, ��� ����� ����� � ��-���������� ������ ������. ��������� ������� ������, ������� ����� \"������ ����\"!",
            ID_Dough = dough3_.DoughId,
            Dough = dough3_,
            ID_Sauce = sauce5_.SauceId,
            Sauces = sauce5_
        };

        db.Pizzas.AddRange(pizza1, pizza2, pizza3, pizza4, pizza5, pizza6);
        db.SaveChanges();
    }
    //----------------------------------------------------
    Ingredient ingredient1 = new Ingredient();
    Ingredient ingredient2 = new Ingredient();
    Ingredient ingredient3 = new Ingredient();
    Ingredient ingredient4 = new Ingredient();
    Ingredient ingredient5 = new Ingredient();
    Ingredient ingredient6 = new Ingredient();
    Ingredient ingredient7 = new Ingredient();
    Ingredient ingredient8 = new Ingredient();
    Ingredient ingredient9 = new Ingredient();
    Ingredient ingredient10 = new Ingredient();
    Ingredient ingredient11 = new Ingredient();
    Ingredient ingredient12 = new Ingredient();
    Ingredient ingredient13 = new Ingredient();

    if (!db.Ingredients.Any())
    {
        ingredient1 = new Ingredient
        {
            Name = "���������",
            Calories = 466,
            Price = 40,
            Photo = "Pepperoni.png"
        };
        ingredient2 = new Ingredient
        {
            Name = "��������",
            Calories = 299,
            Price = 50,
            Photo = "Parmezan.png"
        };
        ingredient3 = new Ingredient
        {
            Name = "������",
            Calories = 404,
            Price = 45,
            Photo = "Chesse.png"
        };
        ingredient4 = new Ingredient
        {
            Name = "����������",
            Calories = 331,
            Price = 55,
            Photo = "Mortad.png"
        };
        ingredient5 = new Ingredient
        {
            Name = "������",
            Calories = 280,
            Price = 89,
            Photo = "Brinza.png"
        };
        ingredient6 = new Ingredient
        {
            Name = "�������",
            Calories = 310,
            Price = 75,
            Photo = "Chiken.png"
        };
        ingredient7 = new Ingredient
        {
            Name = "������",
            Calories = 1050,
            Price = 96,
            Photo = "Pineapple.png"
        };
        ingredient8 = new Ingredient
        {
            Name = "�����",
            Calories = 190,
            Price = 50,
            Photo = "Becon.png"
        };
        ingredient9 = new Ingredient
        {
            Name = "������� ���",
            Calories = 64,
            Price = 45,
            Photo = "Onion.png"
        };
        ingredient10 = new Ingredient
        {
            Name = "��������� �������",
            Calories = 500,
            Price = 120,
            Photo = "Bavar.png"
        };
        ingredient11 = new Ingredient
        {
            Name = "������ ������� ������",
            Calories = 500,
            Price = 109,
            Photo = "Kolbasa.png"
        };
        ingredient12 = new Ingredient
        {
            Name = "���������",
            Calories = 250,
            Price = 70,
            Photo = "Mos.png"
        };
        ingredient13 = new Ingredient
        {
            Name = "����������",
            Calories = 180,
            Price = 55,
            Photo = "Grib.png"
        };

        db.Ingredients.AddRange(ingredient1, ingredient2, ingredient3, ingredient4, ingredient5,
            ingredient6, ingredient7, ingredient8, ingredient9, ingredient10, ingredient11,
            ingredient12, ingredient13);
        db.SaveChanges();
    }
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


