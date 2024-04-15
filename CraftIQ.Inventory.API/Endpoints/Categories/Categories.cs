using CraftIQ.Inventory.Core.Entities;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories
{
    public class Categories(IRepository<Category> repository) : EndpointsAsync
                                                               .WithRequest<CreateCategoriesRequest>
                                                               .WithActionResult<CreateCategoriesResponse>
    {
        private readonly IRepository<Category> _repository = repository;

        [HttpPost(Routes.CategoriesRoutes.Create)]
        public override async Task<ActionResult<CreateCategoriesResponse>> HandleAsync
                       (CreateCategoriesRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("request can't be null", StatusCodes.Status400BadRequest);

            var oData = new Category(request.Name, request.Description);
            var oResult = await _repository.AddAsync(oData);
            return Ok(new CreateCategoriesResponse(oResult.Name, oResult.Description));
        }
    }
}
