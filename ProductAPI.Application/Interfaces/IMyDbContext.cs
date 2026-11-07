using Microsoft.EntityFrameworkCore;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Application.Interfaces;
public interface IMyDbContext
{
    DbSet<Product> Products { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}