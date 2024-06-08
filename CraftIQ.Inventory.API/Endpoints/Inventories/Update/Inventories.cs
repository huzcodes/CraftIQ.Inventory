using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Endpoints.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Inventories.Update
{
    public class Inventories(InventoryFactory<InventoriesOperationsContract, dynamic> factory) : EndpointsAsync.WithRequest<UpdateInventoryRequest>
                                                                                                         .WithActionResult
    {
        private readonly InventoryFactory<InventoriesOperationsContract, dynamic> _factory = factory;

        [HttpPut(Routes.InventoryRoutes.Update)]
        public override async Task<ActionResult> HandleAsync([FromMultiSource] UpdateInventoryRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Inventory));
            var oData = new InventoriesOperationsContract(request.inventoryId,
                                                          request.Inventory.Name,
                                                          request.Inventory.Quantity,
                                                          request.Inventory.Reorderlevel,
                                                          request.Inventory.Location);
            await service.Update(request.inventoryId, oData);
            return Ok("your object has been updated");
        }
    }

}
