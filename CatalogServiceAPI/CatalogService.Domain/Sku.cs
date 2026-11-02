
namespace CatalogService.Domain
{
    public class Sku
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string SkuCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImageKey { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public Product Product { get; set; } = null!;
    }
}
