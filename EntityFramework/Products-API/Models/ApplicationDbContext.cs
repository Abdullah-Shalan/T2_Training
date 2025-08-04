using Products_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Products_API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        //Injection Happens Here!
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    }
}