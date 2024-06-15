using CraftIQ.Inventory.Shared.Contracts.Transactions;

namespace CraftIQ.Inventory.API.Endpoints.Transactions.Read
{
    public class ReadTransactionsResponse
    {
        public Guid TransactionId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int TransactionType { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public ReadTransactionsResponse(TransactionsContract transaction)
        {
            TransactionId = transaction._TransactionId;
            EmployeeId = transaction.EmployeeId;
            TransactionDate = transaction.TransactionDate;
            Quantity = transaction.Quantity;
            TransactionType = transaction.TransactionType;
            Notes = transaction.Notes;
            CreatedOn = transaction.CreatedOn;
            ModifiedOn = transaction.ModifiedOn;
        }
    }

}
