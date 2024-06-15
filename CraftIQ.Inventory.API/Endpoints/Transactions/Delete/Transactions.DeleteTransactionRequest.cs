using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Transactions.Delete
{
    public class DeleteTransactionRequest
    {
        [FromRoute]
        public Guid transactionId { get; set; }
    }
}
