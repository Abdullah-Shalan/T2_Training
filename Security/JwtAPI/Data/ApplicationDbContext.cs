using JwtAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
    public DbSet<User> Users { get; set; }
    }
}