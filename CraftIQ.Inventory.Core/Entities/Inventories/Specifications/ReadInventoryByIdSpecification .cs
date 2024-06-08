using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Inventories.Specifications
{
    public class ReadInventoryByIdSpecification : SingleResultSpecification<Inventory>
    {
        public ReadInventoryByIdSpecification(Guid inventoryId)
        {
            Query.Where(o => o._InventoryId == inventoryId);
        }
    }

}
