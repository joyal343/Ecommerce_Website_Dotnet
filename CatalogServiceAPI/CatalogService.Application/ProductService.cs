using CatalogService.Domain;
using CatalogService.Domain.Interfaces;

namespace CatalogService.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken ct = default)
        {
            var products = await _repository.GetAllAsync(ct);
            return products;
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var product = await _repository.GetByIdAsync(id, ct);
            return product;
        }
    }
}
