using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.OrderDetails.Specifications
{
    public class ReadOrderDetailsByIdSpecification : SingleResultSpecification<OrderDetail>
    {
        public ReadOrderDetailsByIdSpecification(Guid orderDetailId)
        {
            Query.Where(o => o._OrderDetailId == orderDetailId)
                 .Include(o => o.Product)
                 .Include(o => o.Order);
        }
    }
}
