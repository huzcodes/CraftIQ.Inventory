namespace CraftIQ.Inventory.Core.Entities
{
    public class Order : BaseEntity
    {
        public Guid _OrderId { get; set; }
        public Guid SupplierId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; }
        public DateTimeOffset ExpectedDeliveryDate { get; set; }
        public int OrderType { get; set; }
        public DateTimeOffset ReceivedDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}
