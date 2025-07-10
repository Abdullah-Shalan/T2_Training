using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SMSystem;User ID=sa;Password=admin123$;Pooling=False;Connect Timeout=30;Trust Server Certificate=True;Authentication=SqlPassword;Application Name=vscode-mssql;Application Intent=ReadWrite;Command Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d));

        modelBuilder.Entity<Student>()
            .Property(s => s.Birthday)
            .HasConversion(dateOnlyConverter)
            .HasColumnType("date"); 
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<University> Universities { get; set; }


}