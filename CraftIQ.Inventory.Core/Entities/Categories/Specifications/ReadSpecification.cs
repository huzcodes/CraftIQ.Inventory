using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Categories.Specifications
{
    public class ReadSpecification : Specification<Category>
    {
        public ReadSpecification() 
        {
            Query.Where(o => o.Id != 0);
        }
    }
}
