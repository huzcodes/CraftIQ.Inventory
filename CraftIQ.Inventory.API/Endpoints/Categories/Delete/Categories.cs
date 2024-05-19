using CraftIQ.Inventory.Core.Entities.Categories;
using CraftIQ.Inventory.Services.Factories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Delete
{
    public class Categories(InventoryFactory<CategoriesDeleteRequest, ActionResult> factory) : EndpointsAsync.WithRequest<CategoriesDeleteRequest>
                                                                                                         .WithActionResult
    {
        private readonly InventoryFactory<CategoriesDeleteRequest, ActionResult> _factory = factory; 

        [HttpDelete(Routes.CategoriesRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync(CategoriesDeleteRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Category));
            await service.Delete(request.categoryId);
            return Ok("your object deleted successfully");
        }
    }
}
