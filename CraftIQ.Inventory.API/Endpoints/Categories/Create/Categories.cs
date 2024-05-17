using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Create
{
    public class Categories(IGenericServices<CategoriesOperationsContract, CategoriesContract> services) : EndpointsAsync
                                                                                                              .WithRequest<CreateCategoriesRequest>
                                                                                                              .WithActionResult<CreateCategoriesResponse>
    {
        private readonly IGenericServices<CategoriesOperationsContract, CategoriesContract> _services = services;

        [HttpPost(Routes.CategoriesRoutes.BaseUrl)]
        public override async Task<ActionResult<CreateCategoriesResponse>> HandleAsync
                              (CreateCategoriesRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("request can't be null", (int)HttpStatusCode.BadRequest);

            var oData = new CategoriesOperationsContract(request.Name, request.Description);
            var oResult = await _services.CreateCategory(oData);
            return Ok(new CreateCategoriesResponse(oResult.Name, oResult.Description));
        }
    }
}
