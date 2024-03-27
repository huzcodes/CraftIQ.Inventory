using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories
{
    /// <summary>
    /// huzcodes
    /// </summary>
    public class CreateCategory : EndpointsAsync.WithRequest<CreateCategoryRequest>
                                                .WithActionResult<CreateCategoryResponse>
    {
        [HttpPost(Routes.CategoriesRoutes.CreateCategory)]
        public async override Task<ActionResult<CreateCategoryResponse>> HandleAsync
                       (CreateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var oResult = new CreateCategoryResponse(request.Name, request.Description);
            return Ok(oResult);

        }
    }
}
