namespace CraftIQ.Inventory.Shared.Contracts.OrderDetails
{
    public class OrderDetailsContract : OrderDetailsOperationsContract
    {
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public OrderDetailsContract(Guid orderDetailId,
                                    int quantity,
                                    decimal totalPrice,
                                    Guid orderId,
                                    Guid productId)
            : base(orderDetailId, quantity, totalPrice, orderId, productId)
        { }

        public OrderDetailsContract(Guid orderDetailId,
                                    int quantity,
                                    decimal totalPrice,
                                    Guid orderId,
                                    Guid productId,
                                    Guid createdBy,
                                    Guid modifiedBy,
                                    DateTimeOffset createdOn,
                                    DateTimeOffset modifiedOn)
            : base(orderDetailId, quantity, totalPrice, orderId, productId)
        {
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            ModifiedBy = modifiedBy;
            ModifiedOn = modifiedOn;
        }
    }

}
