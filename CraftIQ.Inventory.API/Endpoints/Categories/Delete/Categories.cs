using CraftIQ.Inventory.Core.Interfaces;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Delete
{
    public class Categories(IGenericServices<CategoriesDeleteRequest, ActionResult> services) : EndpointsAsync.WithRequest<CategoriesDeleteRequest>
                                                                                                         .WithActionResult
    {
        private readonly IGenericServices<CategoriesDeleteRequest, ActionResult> _services = services; 

        [HttpDelete(Routes.CategoriesRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync(CategoriesDeleteRequest request, CancellationToken cancellationToken = default)
        {
            await _services.DeleteCategory(request.categoryId);
            return Ok("your object deleted successfully");
        }
    }
}
