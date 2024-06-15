namespace CraftIQ.Inventory.Shared.Contracts.Transactions
{
    public class TransactionsOperationsContract
    {
        public Guid _TransactionId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int TransactionType { get; set; }
        public string Notes { get; set; } = string.Empty;

        public TransactionsOperationsContract(Guid transactionId,
                                              Guid employeeId,
                                              DateTimeOffset transactionDate,
                                              int quantity,
                                              int transactionType,
                                              string notes)
        {
            _TransactionId = transactionId;
            EmployeeId = employeeId;
            TransactionDate = transactionDate;
            Quantity = quantity;
            TransactionType = transactionType;
            Notes = notes;
        }
    }

}
