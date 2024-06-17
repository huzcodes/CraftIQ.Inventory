using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Orders.Delete
{
    public class DeleteOrderRequest
    {
        [FromRoute]
        public Guid orderId { get; set; }
    }

}
