namespace CraftIQ.Inventory.API.Endpoints.Products.Create
{
    public class CreateProductRequest
    {
        public Guid CategoryId { get; set; }
        public Guid InventoryId { get; set; }
        public Guid TransactionId { get; set; }
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

        public CreateProductRequest(Guid categoryId,
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
            CategoryId = categoryId;
            InventoryId = inventoryId;
            TransactionId = transactionId;
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
