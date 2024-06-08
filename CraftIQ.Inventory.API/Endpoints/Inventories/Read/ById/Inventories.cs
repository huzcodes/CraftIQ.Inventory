using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Inventories.Read.ById
{
    public class Inventories(InventoryFactory<InventoriesOperationsContract, InventoriesContract> factory) : EndpointsAsync.WithRequest<ReadInventoryByIdRequest>
                                                                                                                           .WithActionResult<ReadInventoriesResponse>
    {
        private readonly InventoryFactory<InventoriesOperationsContract, InventoriesContract> _factory = factory;

        [HttpGet(Routes.InventoryRoutes.ReadById)]
        public async override Task<ActionResult<ReadInventoriesResponse>> HandleAsync(ReadInventoryByIdRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Inventory));
            var oData = await service.ReadById(request.inventoryId);
            var oResult = new ReadInventoriesResponse(oData);
            return Ok(oResult);
        }
    }

}
