namespace CraftIQ.Inventory.API.Endpoints.Orders.Create
{
    public class CreateOrderRequest
    {
        public Guid SupplierId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; }
        public DateTimeOffset ExpectedDeliveryDate { get; set; }
        public int OrderType { get; set; }
        public DateTimeOffset ReceivedDate { get; set; }
    }

}
