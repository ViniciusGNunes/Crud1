using Crud1.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Crud1.Models;

namespace Crud1.Data;

public class AppDbContext: DbContext
{
    public DbSet<UserModel> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=DataBased;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMapping());
    }
}