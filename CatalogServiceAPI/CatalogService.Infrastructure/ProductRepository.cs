
using CatalogService.Domain;
using CatalogService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _db;

        public ProductRepository(CatalogDbContext db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken ct = default)
        {
            return await _db.Products
                .AsNoTracking()
                .Where(p => p.IsActive)
                .Include(p => p.Skus.Where(s => s.IsActive))
                .OrderBy(p => p.Name)
                .ToListAsync(ct);
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _db.Products
                .AsNoTracking()
                .Where(p => p.IsActive && p.Id == id)
                .Include(p => p.Skus.Where(s => s.IsActive))
                .FirstOrDefaultAsync(ct);
        }
    }
}
