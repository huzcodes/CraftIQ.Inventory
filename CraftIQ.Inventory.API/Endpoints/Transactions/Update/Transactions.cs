using CraftIQ.Inventory.Core.Entities.Transactions;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Transactions;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Endpoints.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Transactions.Update
{
    public class Transactions(InventoryFactory<TransactionsOperationsContract, dynamic> factory) : EndpointsAsync.WithRequest<UpdateTransactionRequest>
                                                                                                             .WithActionResult
    {
        private readonly InventoryFactory<TransactionsOperationsContract, dynamic> _factory = factory;

        [HttpPut(Routes.TransactionsRoutes.Update)]
        public override async Task<ActionResult> HandleAsync([FromMultiSource] UpdateTransactionRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Transaction));
            var oData = new TransactionsOperationsContract(request.transactionId,
                                                           request.Transaction.EmployeeId,
                                                           request.Transaction.TransactionDate,
                                                           request.Transaction.Quantity,
                                                           request.Transaction.TransactionType,
                                                           request.Transaction.Notes);
            await service.Update(request.transactionId, oData);
            return Ok("Your object has been updated");
        }
    }

}
