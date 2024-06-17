using CraftIQ.Inventory.Core.Entities.Orders;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Orders.Create
{
    public class Orders(InventoryFactory<OrdersOperationsContract, OrdersContract> factory) : EndpointsAsync.WithRequest<CreateOrderRequest>
                                                                                                           .WithActionResult<CreateOrderResponse>
    {
        private readonly InventoryFactory<OrdersOperationsContract, OrdersContract> _factory = factory;

        [HttpPost(Routes.OrdersRoutes.BaseUrl)]
        public override async Task<ActionResult<CreateOrderResponse>> HandleAsync([FromBody] CreateOrderRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Order));
            var oData = new OrdersOperationsContract(Guid.Empty,
                                                     request.SupplierId,
                                                     request.OrderDate,
                                                     request.TotalAmount,
                                                     request.Status,
                                                     request.ExpectedDeliveryDate,
                                                     request.OrderType,
                                                     request.ReceivedDate);
            var oCreateOrder = await service.Create(oData);
            var oResult = new CreateOrderResponse(oCreateOrder._OrderId);
            return Ok(oResult);
        }
    }

}
