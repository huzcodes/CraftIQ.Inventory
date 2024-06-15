using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Endpoints.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Update
{
    public class Products(InventoryFactory<ProductsOperationsContract, dynamic> factory) : EndpointsAsync.WithRequest<UpdateProductsRequest>
                                                                                                         .WithActionResult
    {
        private readonly InventoryFactory<ProductsOperationsContract, dynamic> _factory = factory;

        [HttpPut(Routes.ProductsRoutes.Update)]
        public override async Task<ActionResult> HandleAsync([FromMultiSource]UpdateProductsRequest request, CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(Product));
            var oData = new ProductsOperationsContract(request.productId,
                                                       Guid.Empty,
                                                       Guid.Empty,
                                                       Guid.Empty,
                                                       request.Product.Name,
                                                       request.Product.Description,
                                                       request.Product.UnitPrice,
                                                       request.Product.Weight,
                                                       request.Product.Length,
                                                       request.Product.Width,
                                                       request.Product.Height,
                                                       request.Product.TaxCost,
                                                       request.Product.ProfitPerUnit,
                                                       request.Product.ProductionCost);
            await service.Update(request.productId, oData);
            return Ok("your object has been updated");
        }
    }
}
