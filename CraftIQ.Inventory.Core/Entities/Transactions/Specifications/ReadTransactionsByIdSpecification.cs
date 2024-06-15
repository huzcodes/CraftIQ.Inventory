using Ardalis.Specification;

namespace CraftIQ.Inventory.Core.Entities.Transactions.Specifications
{
    public class ReadTransactionsByIdSpecification : SingleResultSpecification<Transaction>
    {
        public ReadTransactionsByIdSpecification(Guid transactionId)
        {
            Query.Where(o => o._TransactionId == transactionId);
        }
    }

}
