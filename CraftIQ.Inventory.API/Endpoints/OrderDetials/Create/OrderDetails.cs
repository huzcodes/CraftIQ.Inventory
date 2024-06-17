using CraftIQ.Inventory.Core.Entities.OrderDetails;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.OrderDetials.Create
{
    public class OrderDetails(InventoryFactory<OrderDetailsOperationsContract, OrderDetailsContract> factory) : EndpointsAsync.WithRequest<CreateOrderDetailRequest>
                                                                                                            .WithActionResult<CreateOrderDetailResponse>
    {
        private readonly InventoryFactory<OrderDetailsOperationsContract, OrderDetailsContract> _factory = factory;

        [HttpPost(Routes.OrderDetailsRoutes.BaseUrl)]
        public override async Task<ActionResult<CreateOrderDetailResponse>> HandleAsync([FromBody] CreateOrderDetailRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(OrderDetail));
            var oData = new OrderDetailsOperationsContract(Guid.Empty,
                                                           request.Quantity,
                                                           request.TotalPrice,
                                                           request.OrderId,
                                                           request.ProductId);
            var oCreateOrderDetail = await service.Create(oData);
            var oResult = new CreateOrderDetailResponse(oCreateOrderDetail._OrderDetailId);
            return Ok(oResult);
        }
    }

}
