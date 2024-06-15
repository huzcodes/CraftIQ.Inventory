using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Products.Specifications
{
    public class ReadProductsSpecification : Specification<Product>
    {
        public ReadProductsSpecification()
        {
            Query.Where(o => o.Id != 0)
                 .Include(o => o.Inventory)
                 .Include(o => o.Transaction);
        }
    }
}
