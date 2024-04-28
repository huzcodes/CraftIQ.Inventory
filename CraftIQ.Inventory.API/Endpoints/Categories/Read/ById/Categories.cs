using CraftIQ.Inventory.Core.Interfaces;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Read.ById
{
    public class Categories(ICategoriesServices services) : EndpointsAsync.WithRequest<ReadCategoriesByIdRequest>
                                            .WithActionResult<ReadCategoriesByIdResponse>
    {
        private readonly ICategoriesServices _services = services;

        [HttpGet(Routes.CategoriesRoutes.ReadById)]
        public override async Task<ActionResult<ReadCategoriesByIdResponse>> HandleAsync(ReadCategoriesByIdRequest request, CancellationToken cancellationToken = default)
        {
            var oData = await _services.ReadCategoryById(request.categoryId);
            var oResult = new ReadCategoriesByIdResponse(oData);
            return Ok(oResult);
        }
    }
}
