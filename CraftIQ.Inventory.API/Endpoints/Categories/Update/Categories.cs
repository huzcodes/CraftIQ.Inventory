using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Update
{
    public class Categories(IGenericServices<CategoriesOperationsContract, CategoriesContract> services) : EndpointsAsync.WithRequest<UpdateCategoriesRequest>
                                                                                                                         .WithActionResult
    {
        private readonly IGenericServices<CategoriesOperationsContract, CategoriesContract> _services = services;

        [HttpPut(Routes.CategoriesRoutes.Update)]
        public override async Task<ActionResult> HandleAsync(UpdateCategoriesRequest request, CancellationToken cancellationToken = default)
        {
            var oData = new CategoriesOperationsContract(request.Category.Name, request.Category.Description);
            await _services.UpdateCategory(request.categoryId, oData);
            return Ok("your object has been updated");
        }
    }
}
