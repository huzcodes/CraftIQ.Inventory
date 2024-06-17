using CraftIQ.Inventory.Core.Entities.Categories;
using CraftIQ.Inventory.Core.Entities.OrderDetails;
using CraftIQ.Inventory.Core.Entities.Transactions;
using CraftIQ.Inventory.Shared.Contracts.Products;

namespace CraftIQ.Inventory.Core.Entities.Products
{
    public class Product : BaseEntity
    {
        public Guid _ProductId { get; set; }
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

        //relation with category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();

        //relation with Inventory
        public int InventoryId { get; set; }
        public Core.Entities.Inventories.Inventory Inventory { get; set; } = new();

        //relation with Transactions
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; } = new();

        // relation with order details
        public List<OrderDetail> OrderDetails { get; set; } = new();

        public Product(string name,
                       string description,
                       decimal unitPrice,
                       float weight,
                       float length,
                       float width,
                       float height,
                       decimal taxCost,
                       decimal profitPerUnit,
                       decimal productionCost)
        {
            _ProductId = Guid.NewGuid();
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            Weight = weight;
            Length = length;
            Width = width;
            Height = height;
            TaxCost = taxCost;
            ProfitPerUnit = profitPerUnit;
            ProductionCost = productionCost;
            CreatedBy = new();
            CreatedOn = DateTimeOffset.Now;
            ModifiedBy = new();
            ModifiedOn = DateTimeOffset.Now;
        }

        public void SetCategory(Category category) =>
            Category = category;

        public void SetInventory(Inventories.Inventory inventory) =>
            Inventory = inventory;

        public void SetTransaction(Transaction transaction) =>
            Transaction = transaction;

        public void UpdateProduct(ProductsOperationsContract product)
        {
            ModifiedOn = DateTimeOffset.Now;
            Name = string.IsNullOrEmpty(product.Name) ? this.Name : product.Name;
            Description = string.IsNullOrEmpty(product.Description) ? this.Description : product.Description;
            UnitPrice = product.UnitPrice == 0 ? this.UnitPrice : product.UnitPrice;
            Weight = product.Weight == 0 ? this.Weight : product.Weight;
            Length = product.Length == 0 ? this.Length : product.Length;
            Width = product.Width == 0 ? this.Width : product.Width;
            Height = product.Height == 0 ? this.Height : product.Height;
            TaxCost = product.TaxCost == 0 ? this.TaxCost : product.TaxCost;
            ProfitPerUnit = product.ProfitPerUnit == 0 ? this.ProfitPerUnit : product.ProfitPerUnit;
            ProductionCost = product.ProductionCost == 0 ? this.ProductionCost : product.ProductionCost;
        }
    }
}
