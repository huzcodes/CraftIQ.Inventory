using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Shared.Contracts.Transactions;

namespace CraftIQ.Inventory.Core.Entities.Transactions
{
    public class Transaction : BaseEntity
    {
        public Guid _TransactionId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int TransactionType { get; set; }
        public string Notes { get; set; } = string.Empty;

        //relation with products
        public List<Product> Products { get; set; } = new();

        public Transaction(){ } // ef core ctor

        public Transaction(Guid employeeId,
                           DateTimeOffset transactionDate,
                           int quantity,
                           int transactionType,
                           string notes)
        {
            _TransactionId = Guid.NewGuid();
            EmployeeId = employeeId;
            TransactionDate = transactionDate;
            Quantity = quantity;
            TransactionType = transactionType;
            Notes = notes;
            CreatedBy = employeeId;
            CreatedOn = DateTimeOffset.Now;
            ModifiedBy = Guid.Empty;
            ModifiedOn = DateTimeOffset.Now;
        }

        public void UpdateTransaction(TransactionsOperationsContract transaction)
        {
            ModifiedOn = DateTimeOffset.Now;
            Notes = string.IsNullOrEmpty(transaction.Notes) ? this.Notes : transaction.Notes;
            Quantity = transaction.Quantity == 0 ? this.Quantity : transaction.Quantity;
            TransactionType = transaction.TransactionType == 0 ? this.TransactionType : transaction.TransactionType;
        }
    }
}
