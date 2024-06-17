using CraftIQ.Inventory.Core.Entities.Orders;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Orders.Read
{
    public class Orders(InventoryFactory<dynamic, OrdersContract> factory) : EndpointsAsync.WithoutRequest
                                                                                      .WithActionResult<ReadOrdersResponse>
    {
        private readonly InventoryFactory<dynamic, OrdersContract> _factory = factory;

        [HttpGet(Routes.OrdersRoutes.BaseUrl)]
        public async override Task<ActionResult<ReadOrdersResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Order));
            var oData = await service.Read();
            var oResult = oData.Select(o => new ReadOrdersResponse(o)).ToList();
            return Ok(oResult);
        }
    }

}
