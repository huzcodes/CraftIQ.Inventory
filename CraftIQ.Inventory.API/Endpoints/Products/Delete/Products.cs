using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Services.Factories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Delete
{
    public class Products(InventoryFactory<DeleteProductRequest, ActionResult> factory) : EndpointsAsync.WithRequest<DeleteProductRequest>
                                                                                                        .WithActionResult
    {
        private readonly InventoryFactory<DeleteProductRequest, ActionResult> _factory = factory;

        [HttpDelete(Routes.ProductsRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync(DeleteProductRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Product));
            await service.Delete(request.productId);
            return Ok("your object deleted successfully");
        }
    }
}
