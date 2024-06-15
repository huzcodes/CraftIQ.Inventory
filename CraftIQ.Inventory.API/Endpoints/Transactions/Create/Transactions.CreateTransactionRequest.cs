namespace CraftIQ.Inventory.API.Endpoints.Transactions.Create
{
    public class CreateTransactionRequest
    {
        public Guid EmployeeId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int TransactionType { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

}
