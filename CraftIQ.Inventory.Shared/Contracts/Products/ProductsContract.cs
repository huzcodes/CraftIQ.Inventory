namespace CraftIQ.Inventory.Shared.Contracts.Products
{
    public class ProductsContract : ProductsOperationsContract
    {
        public ProductsContract(Guid productId,
                                Guid categoryId,
                                Guid inventoryId,
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

        }
        // order details list will be added when we create orders contracts
        //public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}
