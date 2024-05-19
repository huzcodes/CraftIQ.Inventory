using CraftIQ.Inventory.Shared.Contracts.Products;

namespace CraftIQ.Inventory.API.Endpoints.Products.Read
{
    public class ReadProductsResponse
    {
        public Guid ProductId { get; set; }
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
        public ReadProductsResponse(ProductsContract product)
        {
            ProductId = product._ProductId;
            Name = product.Name;
            Description = product.Description;
            UnitPrice = product.UnitPrice;
            Weight = product.Weight;
            Length = product.Length;
            Width = product.Width;
            Height = product.Height;
            TaxCost = product.TaxCost;
            ProfitPerUnit = product.ProfitPerUnit;
            ProductionCost = product.ProductionCost;
        }
    }
}
