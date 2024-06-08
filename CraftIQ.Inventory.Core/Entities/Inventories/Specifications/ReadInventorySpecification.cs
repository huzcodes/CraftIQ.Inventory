using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Inventories.Specifications
{
    public class ReadInventorySpecification : Specification<Inventory>
    {
        public ReadInventorySpecification()
        {
            Query.Where(o => o.Id != 0);
        }
    }

}
