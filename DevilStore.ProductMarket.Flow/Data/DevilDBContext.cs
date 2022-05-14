using DevilStore.ProductMarket.Flow.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevilStore.ProductMarket.Flow.Data
{
    public class DevilDBContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Market> Market { get; set; }
        public DbSet<User> User { get; set; }
        public DevilDBContext(DbContextOptions<DevilDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
