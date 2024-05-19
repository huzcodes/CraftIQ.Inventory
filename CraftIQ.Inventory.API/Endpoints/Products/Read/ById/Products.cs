using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Read.ById
{
    public class Products(InventoryFactory<ProductsOperationsContract, ProductsContract> factory) : EndpointsAsync.WithRequest<ReadProductByIdRequest>
                                                                                                                  .WithActionResult<ReadProductsResponse>
    {
        private readonly InventoryFactory<ProductsOperationsContract, ProductsContract> _factory = factory;

        [HttpGet(Routes.ProductsRoutes.ReadById)]
        public async override Task<ActionResult<ReadProductsResponse>> HandleAsync(ReadProductByIdRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Product));
            var oData = await service.ReadById(request.productId);
            var oResult = new ReadProductsResponse(oData);
            return Ok(oResult);
        }
    }
}
