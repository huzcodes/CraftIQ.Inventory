namespace CraftIQ.Inventory.API.Endpoints.Orders.Create
{
    public class CreateOrderResponse
    {
        public Guid OrderId { get; set; }

        public CreateOrderResponse(Guid orderId)
        {
            OrderId = orderId;
        }
    }

}
