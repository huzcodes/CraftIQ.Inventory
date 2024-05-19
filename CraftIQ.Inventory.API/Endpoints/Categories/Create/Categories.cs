using CraftIQ.Inventory.Core.Entities.Categories;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Create
{
    public class Categories(InventoryFactory<CategoriesOperationsContract, CategoriesContract> factory) : EndpointsAsync
                                                                                                              .WithRequest<CreateCategoriesRequest>
                                                                                                              .WithActionResult<CreateCategoriesResponse>
    {
        private readonly InventoryFactory<CategoriesOperationsContract, CategoriesContract> _factory = factory;

        [HttpPost(Routes.CategoriesRoutes.BaseUrl)]
        public override async Task<ActionResult<CreateCategoriesResponse>> HandleAsync
                              (CreateCategoriesRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("request can't be null", (int)HttpStatusCode.BadRequest);

            var service = _factory.Build(nameof(Category));
            var oData = new CategoriesOperationsContract(request.Name, request.Description);
            var oResult = await service.Create(oData);
            return Ok(new CreateCategoriesResponse(oResult.Name, oResult.Description));
        }
    }
}
