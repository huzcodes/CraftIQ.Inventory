using CraftIQ.Inventory.Core.Entities.OrderDetails;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.OrderDetials.Read
{
    public class OrderDetails(InventoryFactory<dynamic, OrderDetailsContract> factory) : EndpointsAsync.WithoutRequest
                                                                                                  .WithActionResult<ReadOrderDetailsResponse>
    {
        private readonly InventoryFactory<dynamic, OrderDetailsContract> _factory = factory;

        [HttpGet(Routes.OrderDetailsRoutes.BaseUrl)]
        public async override Task<ActionResult<ReadOrderDetailsResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(OrderDetail));
            var oData = await service.Read();
            var oResult = oData.Select(o => new ReadOrderDetailsResponse(o)).ToList();
            return Ok(oResult);
        }
    }

}
