using CraftIQ.Inventory.Core.Entities.Orders;
using CraftIQ.Inventory.Services.Factories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Orders.Delete
{
    public class Orders(InventoryFactory<DeleteOrderRequest, ActionResult> factory) : EndpointsAsync.WithRequest<DeleteOrderRequest>
                                                                                                  .WithActionResult
    {
        private readonly InventoryFactory<DeleteOrderRequest, ActionResult> _factory = factory;

        [HttpDelete(Routes.OrdersRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync(DeleteOrderRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Order));
            await service.Delete(request.orderId);
            return Ok("Your object has been deleted successfully");
        }
    }

}
