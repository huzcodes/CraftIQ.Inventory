using CraftIQ.Inventory.Core.Entities.Orders;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Orders.Read.ById
{
    public class Orders(InventoryFactory<OrdersOperationsContract, OrdersContract> factory) : EndpointsAsync.WithRequest<ReadOrderByIdRequest>
                                                                                                        .WithActionResult<ReadOrdersResponse>
    {
        private readonly InventoryFactory<OrdersOperationsContract, OrdersContract> _factory = factory;

        [HttpGet(Routes.OrdersRoutes.ReadById)]
        public async override Task<ActionResult<ReadOrdersResponse>> HandleAsync(ReadOrderByIdRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Order));
            var oData = await service.ReadById(request.orderId);
            var oResult = new ReadOrdersResponse(oData);
            return Ok(oResult);
        }
    }

}
