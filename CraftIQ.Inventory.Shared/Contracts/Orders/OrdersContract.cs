namespace CraftIQ.Inventory.Shared.Contracts.Orders
{
    public class OrdersContract : OrdersOperationsContract
    {
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public OrdersContract(Guid orderId,
                              Guid supplierId,
                              DateTimeOffset orderDate,
                              int totalAmount,
                              int status,
                              DateTimeOffset expectedDeliveryDate,
                              int orderType,
                              DateTimeOffset receivedDate)
            : base(orderId, supplierId, orderDate, totalAmount, status, expectedDeliveryDate, orderType, receivedDate)
        { }

        public OrdersContract(Guid orderId,
                              Guid supplierId,
                              DateTimeOffset orderDate,
                              int totalAmount,
                              int status,
                              DateTimeOffset expectedDeliveryDate,
                              int orderType,
                              DateTimeOffset receivedDate,
                              Guid createdBy,
                              Guid modifiedBy,
                              DateTimeOffset createdOn,
                              DateTimeOffset modifiedOn)
            : base(orderId, supplierId, orderDate, totalAmount, status, expectedDeliveryDate, orderType, receivedDate)
        {
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            ModifiedBy = modifiedBy;
            ModifiedOn = modifiedOn;
        }
    }

}
