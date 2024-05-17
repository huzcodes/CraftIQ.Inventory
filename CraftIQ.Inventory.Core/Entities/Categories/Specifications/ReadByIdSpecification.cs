using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Categories.Specifications
{
    public class ReadByIdSpecification : SingleResultSpecification<Category>
    {
        public ReadByIdSpecification(Guid categoryId) 
        {
            Query.Where(o => o._CategoryId == categoryId);
        }
    }
}
