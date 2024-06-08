using CraftIQ.Inventory.Services.Factories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Inventories.Delete
{
    public class Inventories(InventoryFactory<DeleteInventoryRequest, ActionResult> factory) : EndpointsAsync.WithRequest<DeleteInventoryRequest>
                                                                                                         .WithActionResult
    {
        private readonly InventoryFactory<DeleteInventoryRequest, ActionResult> _factory = factory;

        [HttpDelete(Routes.InventoryRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync(DeleteInventoryRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Inventory));
            await service.Delete(request.inventoryId);
            return Ok("your object deleted successfully");
        }
    }

}
