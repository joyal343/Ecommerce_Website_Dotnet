using CatalogService.Application;
using CatalogService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [ApiController]
    [Route("catalog")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET /products
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAll(CancellationToken ct)
        {
            var products = await _productService.GetAllAsync(ct);
            return Ok(products);
        }

        // GET /products/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Product>> GetById(Guid id, CancellationToken ct)
        {
            var product = await _productService.GetByIdAsync(id, ct);
            return product is null ? NotFound() : Ok(product);
        }
    }
}
