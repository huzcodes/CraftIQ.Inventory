using CraftIQ.Inventory.Shared.Contracts.OrderDetails;

namespace CraftIQ.Inventory.API.Endpoints.OrderDetials.Read
{
    public class ReadOrderDetailsResponse
    {
        public Guid OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public ReadOrderDetailsResponse(OrderDetailsContract orderDetail)
        {
            OrderDetailId = orderDetail._OrderDetailId;
            Quantity = orderDetail.Quantity;
            TotalPrice = orderDetail.TotalPrice;
            OrderId = orderDetail.OrderId;
            ProductId = orderDetail.ProductId;
            CreatedOn = orderDetail.CreatedOn;
            ModifiedOn = orderDetail.ModifiedOn;
        }
    }

}
