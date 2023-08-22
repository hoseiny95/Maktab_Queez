using Microsoft.EntityFrameworkCore;
using Queez20.Models;
using System.Diagnostics;

namespace Queez20.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne<Category>(s => s.category)
            .WithMany(g => g.Products)
            .HasForeignKey(s => s.CategoryId);



    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
