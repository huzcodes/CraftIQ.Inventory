using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Orders.Specifications
{
    public class ReadOrdersSpecification : Specification<Order>
    {
        public ReadOrdersSpecification()
        {
            Query.Where(o => o.Id != 0);
        }
    }

}
