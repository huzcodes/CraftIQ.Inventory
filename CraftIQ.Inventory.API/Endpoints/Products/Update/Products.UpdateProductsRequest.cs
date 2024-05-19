using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Update
{
    public class UpdateProductsRequest
    {
        [FromRoute]
        public Guid productId { get; set; }
        [FromBody]
        public ProductBody Product { get; set; } = null!;
    }

    public class ProductBody
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public float Weight { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public decimal TaxCost { get; set; }
        public decimal ProfitPerUnit { get; set; }
        public decimal ProductionCost { get; set; }
    }
}
