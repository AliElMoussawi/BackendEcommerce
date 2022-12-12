using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
namespace BackendEcommerce.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }
        public DbSet<User> Users{ get; set; }
        public DbSet<ProductCategory> ProductCategories{ get; set; }
        public DbSet<Password> Passwords{ get; set; }

    }
}