using Azure;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Read.ById
{
    public class Categories(IGenericServices<dynamic, CategoriesContract> services) : EndpointsAsync.WithRequest<ReadCategoriesByIdRequest>
                                                                                                   .WithActionResult<ReadCategoriesByIdResponse>
    {
        private readonly IGenericServices<dynamic, CategoriesContract> _services = services;

        [HttpGet(Routes.CategoriesRoutes.ReadById)]
        public override async Task<ActionResult<ReadCategoriesByIdResponse>> HandleAsync(ReadCategoriesByIdRequest request, CancellationToken cancellationToken = default)
        {
            var oData = await _services.ReadCategoryById(request.categoryId);
            var oResult = new ReadCategoriesByIdResponse(oData);
            return Ok(oResult);
        }
    }
}
