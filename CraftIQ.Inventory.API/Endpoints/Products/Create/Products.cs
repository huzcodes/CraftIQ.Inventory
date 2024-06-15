using CraftIQ.Inventory.Core.Entities.Categories;
using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Create
{
    public class Products(InventoryFactory<ProductsOperationsContract, ProductsContract> factory) : EndpointsAsync.WithRequest<CreateProductRequest>
                                                                                                                   .WithActionResult<CreateProductResponse>
    {
        private readonly InventoryFactory<ProductsOperationsContract, ProductsContract> _factory = factory;

        [HttpPost(Routes.ProductsRoutes.BaseUrl)]
        public override async Task<ActionResult<CreateProductResponse>> HandleAsync([FromBody]CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Product));
            var oData = new ProductsOperationsContract(Guid.Empty,
                                                       request.CategoryId,
                                                       request.InventoryId,
                                                       request.TransactionId,
                                                       request.Name,
                                                       request.Description,
                                                       request.UnitPrice,
                                                       request.Weight,
                                                       request.Length,
                                                       request.Width,
                                                       request.Height,
                                                       request.TaxCost,
                                                       request.ProfitPerUnit,
                                                       request.ProductionCost);
            var oCreateProduct = await service.Create(oData);
            var oResult = new CreateProductResponse(oCreateProduct._ProductId);
            return Ok(oResult);
        }
    }
}
