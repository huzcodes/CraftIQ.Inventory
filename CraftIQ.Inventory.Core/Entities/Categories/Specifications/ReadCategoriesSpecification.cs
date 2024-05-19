using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Categories.Specifications
{
    public class ReadCategoriesSpecification : Specification<Category>
    {
        public ReadCategoriesSpecification() 
        {
            Query.Where(o => o.Id != 0);
        }
    }
}
