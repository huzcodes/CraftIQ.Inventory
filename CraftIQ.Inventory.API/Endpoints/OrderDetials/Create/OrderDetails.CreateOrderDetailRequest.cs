namespace CraftIQ.Inventory.API.Endpoints.OrderDetials.Create
{
    public class CreateOrderDetailRequest
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }

}
