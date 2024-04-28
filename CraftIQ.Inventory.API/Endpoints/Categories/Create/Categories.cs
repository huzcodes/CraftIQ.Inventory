using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Create
{
    public class Categories(ICategoriesServices services) : EndpointsAsync
                                                               .WithRequest<CreateCategoriesRequest>
                                                               .WithActionResult<CreateCategoriesResponse>
    {
        private readonly ICategoriesServices _services = services;

        [HttpPost(Routes.CategoriesRoutes.BaseUrl)]
        public override async Task<ActionResult<CreateCategoriesResponse>> HandleAsync
                       (CreateCategoriesRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("request can't be null", StatusCodes.Status400BadRequest);

            var oData = new CategoriesOperationsContract(request.Name, request.Description);
            var oResult = await _services.CreateCategory(oData);
            return Ok(new CreateCategoriesResponse(oResult.Name, oResult.Description));
        }
    }
}
