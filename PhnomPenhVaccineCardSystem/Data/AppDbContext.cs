using Microsoft.EntityFrameworkCore;
using PhnomPenhVaccineCardSystem.Models;

namespace PhnomPenhVaccineCardSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VaccineCard> VaccineCards { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=sql1;Database=CovidDB;User Id=sa;Password=<YourStrong@Passw0rd>;");
            }
        }
    }
}
