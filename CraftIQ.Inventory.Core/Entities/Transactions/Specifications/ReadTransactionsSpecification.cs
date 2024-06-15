using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Transactions.Specifications
{
    public class ReadTransactionsSpecification : Specification<Transaction>
    {
        public ReadTransactionsSpecification()
        {
            Query.Where(o => o.Id != 0);
        }
    }

}
