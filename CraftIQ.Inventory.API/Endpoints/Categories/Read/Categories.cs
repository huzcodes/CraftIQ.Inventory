using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Read
{
    public class Categories(IGenericServices<dynamic, CategoriesContract> services) : EndpointsAsync.WithoutRequest
                                                                                                          .WithActionResult<ReadCategoriesResponse>
    {
        private readonly IGenericServices<dynamic, CategoriesContract> _services = services;

        [HttpGet(Routes.CategoriesRoutes.BaseUrl)]
        public override async Task<ActionResult<ReadCategoriesResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var oData = await _services.Read();
            var oResult = oData.Select(o => new ReadCategoriesResponse(o))
                               .ToList();
            return Ok(oResult);
        }
    }
}
