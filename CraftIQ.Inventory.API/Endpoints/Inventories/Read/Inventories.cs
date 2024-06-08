using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Inventories.Read
{
    public class Inventories(InventoryFactory<dynamic, InventoriesContract> factory) : EndpointsAsync.WithoutRequest
                                                                                                     .WithActionResult<ReadInventoriesResponse>
    {
        private readonly InventoryFactory<dynamic, InventoriesContract> _factory = factory;

        [HttpGet(Routes.InventoryRoutes.BaseUrl)]
        public async override Task<ActionResult<ReadInventoriesResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Inventory));
            var oData = await service.Read();
            var oResult = oData.Select(o => new ReadInventoriesResponse(o)).ToList();
            return Ok(oResult);
        }
    }

}
