using CraftIQ.Inventory.Core.Entities.OrderDetails;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.OrderDetials.Read.ById
{
    public class OrderDetails(InventoryFactory<OrderDetailsOperationsContract, OrderDetailsContract> factory) : EndpointsAsync.WithRequest<ReadOrderDetailByIdRequest>
                                                                                                                     .WithActionResult<ReadOrderDetailsResponse>
    {
        private readonly InventoryFactory<OrderDetailsOperationsContract, OrderDetailsContract> _factory = factory;

        [HttpGet(Routes.OrderDetailsRoutes.ReadById)]
        public async override Task<ActionResult<ReadOrderDetailsResponse>> HandleAsync(ReadOrderDetailByIdRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(OrderDetail));
            var oData = await service.ReadById(request.orderDetailId);
            var oResult = new ReadOrderDetailsResponse(oData);
            return Ok(oResult);
        }
    }

}
