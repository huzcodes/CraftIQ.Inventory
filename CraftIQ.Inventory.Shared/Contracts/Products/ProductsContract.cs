using CraftIQ.Inventory.Shared.Contracts.Inventories;

namespace CraftIQ.Inventory.Shared.Contracts.Products
{
    public class ProductsContract : ProductsOperationsContract
    {
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public Guid InventoryId { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public ProductsContract(Guid productId,
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
                                decimal productionCost) : base(productId,
                                                               categoryId,
                                                               inventoryId,
                                                               transactionId,
                                                               name,
                                                               description,
                                                               unitPrice,
                                                               weight,
                                                               length,
                                                               width,
                                                               height,
                                                               taxCost,
                                                               profitPerUnit,
                                                               productionCost){ }

        public ProductsContract(Guid productId,
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
                                decimal productionCost,
                                Guid createdBy,
                                Guid modifiedBy,
                                DateTimeOffset createdOn,
                                DateTimeOffset modifiedOn,
                                int quantity,
                                int reorderLevel) : base(productId,
                                                         categoryId,
                                                         inventoryId,
                                                         transactionId,
                                                         name,
                                                         description,
                                                         unitPrice,
                                                         weight,
                                                         length,
                                                         width,
                                                         height,
                                                         taxCost,
                                                         profitPerUnit,
                                                         productionCost)
        {
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            ModifiedBy = modifiedBy;
            ModifiedOn = modifiedOn;
            InventoryId = inventoryId;
            Quantity = quantity;
            ReorderLevel = reorderLevel;
        }

        // order details list will be added when we create orders contracts
        //public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}
