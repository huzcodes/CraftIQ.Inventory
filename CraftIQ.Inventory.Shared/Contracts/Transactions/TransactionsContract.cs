namespace CraftIQ.Inventory.Shared.Contracts.Transactions
{
    public class TransactionsContract : TransactionsOperationsContract
    {
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public TransactionsContract(Guid transactionId,
                                    Guid employeeId,
                                    DateTimeOffset transactionDate,
                                    int quantity,
                                    int transactionType,
                                    string notes)
            : base(transactionId, employeeId, transactionDate, quantity, transactionType, notes)
        { }

        public TransactionsContract(Guid transactionId,
                                    Guid employeeId,
                                    DateTimeOffset transactionDate,
                                    int quantity,
                                    int transactionType,
                                    string notes,
                                    Guid createdBy,
                                    Guid modifiedBy,
                                    DateTimeOffset createdOn,
                                    DateTimeOffset modifiedOn)
            : base(transactionId, employeeId, transactionDate, quantity, transactionType, notes)
        {
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            ModifiedBy = modifiedBy;
            ModifiedOn = modifiedOn;
        }
    }

}
