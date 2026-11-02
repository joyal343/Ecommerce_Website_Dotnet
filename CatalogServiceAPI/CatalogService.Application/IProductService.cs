using CatalogService.Domain;

namespace CatalogService.Application
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync(CancellationToken ct = default);
        Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
    }
}