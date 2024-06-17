using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.OrderDetials.Update
{
    public class UpdateOrderDetailRequest
    {
        [FromRoute]
        public Guid orderDetailId { get; set; }
        [FromBody]
        public OrderDetailBody OrderDetail { get; set; } = null!;
    }

    public class OrderDetailBody
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }

}
