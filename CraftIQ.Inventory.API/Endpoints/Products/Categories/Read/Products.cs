using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Categories.Read
{
    public class Products(InventoryFactory<ReadProductsByCategoryIdRequest, ProductsContract> factory) : EndpointsAsync.WithRequest<ReadProductsByCategoryIdRequest>
                                          .WithActionResult<ReadProductsByCategoryIdResponse>
    {
        private readonly InventoryFactory<ReadProductsByCategoryIdRequest, ProductsContract> _factory = factory;

        [HttpGet(Routes.ProductsRoutes.ReadByCategoryId)]
        public override async Task<ActionResult<ReadProductsByCategoryIdResponse>> HandleAsync(ReadProductsByCategoryIdRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Product));
            var oData = await service.ReadByParentId(request.categoryId);
            var oResult = oData.Select(o => new ReadProductsByCategoryIdResponse(o))
                               .ToList();
            return Ok(oResult);
        }
    }
}
