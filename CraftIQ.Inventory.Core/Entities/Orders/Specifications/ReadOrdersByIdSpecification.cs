using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Orders.Specifications
{
    public class ReadOrdersByIdSpecification : SingleResultSpecification<Order>
    {
        public ReadOrdersByIdSpecification(Guid orderId)
        {
            Query.Where(o => o._OrderId == orderId);
        }
    }

}
