using CraftIQ.Inventory.Core.Entities.OrderDetails;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Endpoints.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.OrderDetials.Update
{
    public class OrderDetails(InventoryFactory<OrderDetailsOperationsContract, dynamic> factory) : EndpointsAsync.WithRequest<UpdateOrderDetailRequest>
                                                                                                            .WithActionResult
    {
        private readonly InventoryFactory<OrderDetailsOperationsContract, dynamic> _factory = factory;

        [HttpPut(Routes.OrderDetailsRoutes.Update)]
        public override async Task<ActionResult> HandleAsync([FromMultiSource] UpdateOrderDetailRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(OrderDetail));
            var oData = new OrderDetailsOperationsContract(request.orderDetailId,
                                                           request.OrderDetail.Quantity,
                                                           request.OrderDetail.TotalPrice,
                                                           Guid.Empty,
                                                           Guid.Empty);
            await service.Update(request.orderDetailId, oData);
            return Ok("Your object has been updated");
        }
    }

}
