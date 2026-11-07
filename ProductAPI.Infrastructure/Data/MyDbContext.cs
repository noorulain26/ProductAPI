using Microsoft.EntityFrameworkCore;
using ProductAPI.Application.Interfaces;
using ProductAPI.Domain.Entities; 

namespace ProductAPI.Infrastructure.Data; 
public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options), IMyDbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasMaxLength(100);

            // Fixed: Explicitly setting column type for decimal fields
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(e => e.StockQuantity)
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .IsRequired();
        });
    }
}
