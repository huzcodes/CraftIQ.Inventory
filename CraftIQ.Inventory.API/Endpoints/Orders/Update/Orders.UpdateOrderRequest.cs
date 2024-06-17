using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Orders.Update
{
    public class UpdateOrderRequest
    {
        [FromRoute]
        public Guid orderId { get; set; }
        [FromBody]
        public OrderBody Order { get; set; } = null!;
    }

    public class OrderBody
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
