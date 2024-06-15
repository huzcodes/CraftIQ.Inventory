using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Transactions.Update
{
    public class UpdateTransactionRequest
    {
        [FromRoute]
        public Guid transactionId { get; set; }
        [FromBody]
        public TransactionBody Transaction { get; set; } = null!;
    }

    public class TransactionBody
    {
        public Guid EmployeeId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int TransactionType { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

}
