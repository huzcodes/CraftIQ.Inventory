using CraftIQ.Inventory.Shared.Contracts.Orders;

namespace CraftIQ.Inventory.API.Endpoints.Orders.Read
{
    public class ReadOrdersResponse
    {
        public Guid OrderId { get; set; }
        public Guid SupplierId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; }
        public DateTimeOffset ExpectedDeliveryDate { get; set; }
        public int OrderType { get; set; }
        public DateTimeOffset ReceivedDate { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public ReadOrdersResponse(OrdersContract order)
        {
            OrderId = order._OrderId;
            SupplierId = order.SupplierId;
            OrderDate = order.OrderDate;
            TotalAmount = order.TotalAmount;
            Status = order.Status;
            ExpectedDeliveryDate = order.ExpectedDeliveryDate;
            OrderType = order.OrderType;
            ReceivedDate = order.ReceivedDate;
            CreatedOn = order.CreatedOn;
            ModifiedOn = order.ModifiedOn;
        }
    }

}
