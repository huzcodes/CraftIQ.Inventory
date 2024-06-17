using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.OrderDetails.Specifications
{
    public class ReadOrderDetailsSpecification : Specification<OrderDetail>
    {
        public ReadOrderDetailsSpecification()
        {
            Query.Where(o => o.Id != 0);
        }
    }

}
