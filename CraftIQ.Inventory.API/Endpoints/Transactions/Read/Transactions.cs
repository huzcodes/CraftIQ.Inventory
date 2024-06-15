using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Transactions;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace CraftIQ.Inventory.API.Endpoints.Transactions.Read
{
    public class Transactions(InventoryFactory<dynamic, TransactionsContract> factory) : EndpointsAsync.WithoutRequest
                                                                                                 .WithActionResult<ReadTransactionsResponse>
    {
        private readonly InventoryFactory<dynamic, TransactionsContract> _factory = factory;

        [HttpGet(Routes.TransactionsRoutes.BaseUrl)]
        public async override Task<ActionResult<ReadTransactionsResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Transaction));
            var oData = await service.Read();
            var oResult = oData.Select(o => new ReadTransactionsResponse(o)).ToList();
            return Ok(oResult);
        }
    }

}
