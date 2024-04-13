using Microsoft.EntityFrameworkCore;

namespace Momo_Pizza.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Basket> Baskets { get; set; } = null!;
        public DbSet<Dough> Doughs { get; set; } = null!;
        public DbSet<Filling> Fillings { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Pizza> Pizzas { get; set; } = null!;
        public DbSet<Sauce> Sauces { get; set; } = null!;

        public  DbSet<Authorized> Authorizeds { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Momo_Pizza;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }


    }
}
