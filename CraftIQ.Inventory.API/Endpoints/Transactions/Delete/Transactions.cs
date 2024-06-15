using CraftIQ.Inventory.Core.Entities.Transactions;
using CraftIQ.Inventory.Services.Factories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Transactions.Delete
{
    public class Transactions(InventoryFactory<DeleteTransactionRequest, ActionResult> factory) : EndpointsAsync.WithRequest<DeleteTransactionRequest>
                                                                                                         .WithActionResult
    {
        private readonly InventoryFactory<DeleteTransactionRequest, ActionResult> _factory = factory;

        [HttpDelete(Routes.TransactionsRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync(DeleteTransactionRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Transaction));
            await service.Delete(request.transactionId);
            return Ok("Your object has been deleted successfully");
        }
    }

}
