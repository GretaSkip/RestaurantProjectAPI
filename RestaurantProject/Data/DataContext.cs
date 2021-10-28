using Microsoft.EntityFrameworkCore;
using RestaurantProject.Entities;

namespace RestaurantProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Meniu> Menius { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
