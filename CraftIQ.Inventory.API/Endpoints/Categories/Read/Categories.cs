using CraftIQ.Inventory.Core.Interfaces;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Read
{
    public class Categories(ICategoriesServices services) : EndpointsAsync.WithoutRequest
                                                                           .WithActionResult<ReadCategoriesResponse>
    {
        private readonly ICategoriesServices _services = services;

        [HttpGet(Routes.CategoriesRoutes.BaseUrl)]
        public override async Task<ActionResult<ReadCategoriesResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var oData = await _services.ReadCategories();
            var oResult = oData.Select(o => new ReadCategoriesResponse(o))
                               .ToList();
            return Ok(oResult);
        }
    }
}
