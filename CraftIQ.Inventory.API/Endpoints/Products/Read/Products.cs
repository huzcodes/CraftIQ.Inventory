using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Read
{
    public class Products(InventoryFactory<dynamic, ProductsContract> factory) : EndpointsAsync.WithoutRequest
                                                                                                .WithActionResult<ReadProductsResponse>
    {
        private readonly InventoryFactory<dynamic, ProductsContract> _factory = factory;

        [HttpGet(Routes.ProductsRoutes.BaseUrl)]
        public async override Task<ActionResult<ReadProductsResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Product));
            var oData = await service.Read();
            var oResult = oData.Select(o => new ReadProductsResponse(o))
                               .ToList();
            return Ok(oResult);
        }
    }
}
