using CraftIQ.Inventory.Core.Entities.Products;

namespace CraftIQ.Inventory.Core.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid _OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        //relation with orders
        public int OrderId { get; set; }
        public Order Order { get; set; } = new();

        //relation with products
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
