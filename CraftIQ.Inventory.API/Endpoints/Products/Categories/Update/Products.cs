using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Services.Factories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Endpoints.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Categories.Update
{
    public class Products(InventoryFactory<UpdateProductCategoryRequest, ActionResult> factory) : EndpointsAsync.WithRequest<UpdateProductCategoryRequest>
                                                                                                                .WithActionResult
    {
        private readonly InventoryFactory<UpdateProductCategoryRequest, ActionResult> _factory = factory;

        [HttpPut(Routes.ProductsRoutes.UpdateProductCategoryId)]
        public override async Task<ActionResult> HandleAsync([FromMultiSource]UpdateProductCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Product));
            await service.UpdateParentId(request.productId, request.Product.CategoryId);
            return Ok("your object has been updated");
        }
    }
}
