using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Products.Specifications
{
    public class ReadProductsByIdSpecification : SingleResultSpecification<Product>
    {
        public ReadProductsByIdSpecification(Guid productsId)
        {
            Query.Where(o => o._ProductId == productsId)
                  .Include(o => o.Inventory)
                  .Include(o => o.Transaction);
        }
    }
}
