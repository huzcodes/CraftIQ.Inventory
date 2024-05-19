using CraftIQ.Inventory.Core.Entities.Categories;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Read
{
    public class Categories(InventoryFactory<dynamic, CategoriesContract> factory) : EndpointsAsync.WithoutRequest
                                                                                                   .WithActionResult<ReadCategoriesResponse>
    {
        private readonly InventoryFactory<dynamic, CategoriesContract> _factory = factory;

        [HttpGet(Routes.CategoriesRoutes.BaseUrl)]
        public override async Task<ActionResult<ReadCategoriesResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Category));
            var oData = await service.Read();
            var oResult = oData.Select(o => new ReadCategoriesResponse(o))
                               .ToList();
            return Ok(oResult);
        }
    }
}
