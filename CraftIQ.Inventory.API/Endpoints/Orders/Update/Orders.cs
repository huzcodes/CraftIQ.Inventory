using CraftIQ.Inventory.Core.Entities.Orders;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Endpoints.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Orders.Update
{
    public class Orders(InventoryFactory<OrdersOperationsContract, dynamic> factory) : EndpointsAsync.WithRequest<UpdateOrderRequest>
                                                                                                 .WithActionResult
    {
        private readonly InventoryFactory<OrdersOperationsContract, dynamic> _factory = factory;

        [HttpPut(Routes.OrdersRoutes.Update)]
        public override async Task<ActionResult> HandleAsync([FromMultiSource] UpdateOrderRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Order));
            var oData = new OrdersOperationsContract(request.orderId,
                                                     request.Order.SupplierId,
                                                     request.Order.OrderDate,
                                                     request.Order.TotalAmount,
                                                     request.Order.Status,
                                                     request.Order.ExpectedDeliveryDate,
                                                     request.Order.OrderType,
                                                     request.Order.ReceivedDate);
            await service.Update(request.orderId, oData);
            return Ok("Your object has been updated");
        }
    }

}
