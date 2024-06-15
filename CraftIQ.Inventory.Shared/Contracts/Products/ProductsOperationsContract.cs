namespace CraftIQ.Inventory.Shared.Contracts.Products
{
    public class ProductsOperationsContract
    {
        public Guid _ProductId { get; set; }
        public Guid _CategoryId { get; set; }
        public Guid _InventoryId { get; set; }
        public Guid _TransactionId { get; set; }
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
        public ProductsOperationsContract(Guid productId,
                                          Guid categoryId,
                                          Guid inventoryId,
                                          Guid transactionId,
                                          string name,
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
            _ProductId = productId;
            _CategoryId = categoryId;
            _InventoryId = inventoryId;
            _TransactionId = transactionId;
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
        }
    }
}
