namespace CraftIQ.Inventory.API.Endpoints.OrderDetials.Create
{
    public class CreateOrderDetailResponse
    {
        public Guid OrderDetailId { get; set; }

        public CreateOrderDetailResponse(Guid orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }

}
