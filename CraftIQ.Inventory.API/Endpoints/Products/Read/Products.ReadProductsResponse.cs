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
        public Guid InventoryId { get; set; }
        public Guid TransactionId { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
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
            InventoryId = product.InventoryId;
            TransactionId = product._TransactionId;
            Quantity = product.Quantity;
            ReorderLevel = product.ReorderLevel;
            CreatedBy = product.CreatedBy;
            ModifiedBy = product.ModifiedBy;
            CreatedOn = product.CreatedOn;
            ModifiedOn = product.ModifiedOn;
        }
    }
}
