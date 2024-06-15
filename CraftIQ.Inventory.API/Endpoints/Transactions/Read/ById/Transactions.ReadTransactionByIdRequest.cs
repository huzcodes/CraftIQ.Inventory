using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Transactions.Read.ById
{
    public class ReadTransactionByIdRequest
    {
        [FromRoute]
        public Guid transactionId { get; set; }
    }

}
