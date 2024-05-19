using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Categories.Read.ById
{
    public class Products(InventoryFactory<ReadProductByCategoryIdRequest, ProductsContract> factory) : EndpointsAsync.WithRequest<ReadProductByCategoryIdRequest>
                                                                                                              .WithActionResult<ReadProductsByCategoryIdResponse>
    {
        private readonly InventoryFactory<ReadProductByCategoryIdRequest, ProductsContract> _factory = factory;

        [HttpGet(Routes.ProductsRoutes.ReadSingleByCategoryId)]
        public override async Task<ActionResult<ReadProductsByCategoryIdResponse>> HandleAsync(ReadProductByCategoryIdRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Product));
            var oData = await service.ReadSingleByParentId(request.productId, request.categoryId);
            var oResult = new ReadProductsByCategoryIdResponse(oData);
            return Ok(oResult);
        }
    }
}
