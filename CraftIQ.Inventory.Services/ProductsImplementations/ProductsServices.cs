using CraftIQ.Inventory.Core.Entities.Categories;
using CraftIQ.Inventory.Core.Entities.Categories.Specifications;
using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Core.Entities.Products.Specifications;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System.Net;

namespace CraftIQ.Inventory.Services.ProductsImplementations
{
    public class ProductsServices<TRequest, TResponse>
                 (IRepository<Category> categoryRepository, IRepository<Product> productRepository) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<Category> _categoryRepository = categoryRepository;
        private readonly IRepository<Product> _productRepository = productRepository;
        public async ValueTask<TRequest> Create(TRequest contract)
        {
            var oContract = contract as ProductsOperationsContract;
            var oCategoryReadByIdSpec = new ReadCategoriesByIdSpecification(oContract!._CategoryId);
            var oCategory = await _categoryRepository.FirstOrDefaultAsync(oCategoryReadByIdSpec);
            if (oCategory == null)
                throw new ResultException("you can't add product in category that not exist!", (int)HttpStatusCode.NotFound);

            var oProducts = new Product(oContract.Name,
                                        oContract.Description,
                                        oContract.UnitPrice,
                                        oContract.Weight,
                                        oContract.Length,
                                        oContract.Width,
                                        oContract.Height,
                                        oContract.TaxCost,
                                        oContract.ProfitPerUnit,
                                        oContract.ProductionCost);
            oProducts.SetCategory(oCategory);
            var oProductResult = await _productRepository.AddAsync(oProducts);
            if (oProductResult == null)
                return default!;

            oContract._ProductId = oProductResult._ProductId;
            return oContract as dynamic;
        }

        public async ValueTask Delete(Guid productId)
        {
            var oReadByIdSpec = new ReadProductsByIdSpecification(productId);
            var oResult = await _productRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                await _productRepository.DeleteAsync(oResult);
            else throw new ResultException("You can't delete object that is not exit.", (int)HttpStatusCode.Forbidden);
        }

        public async ValueTask<List<TResponse>> Read()
        {
            var oReadSpec = new ReadProductsSpecification();
            var oData = await _productRepository.ListAsync(oReadSpec);
            if (oData != null && oData.Count > 0)
            {
                var oResult = oData.Select(o => new ProductsContract(o._ProductId,
                                                                     Guid.Empty,
                                                                     Guid.Empty,
                                                                     o.Name,
                                                                     o.Description,
                                                                     o.UnitPrice,
                                                                     o.Weight,
                                                                     o.Length,
                                                                     o.Width,
                                                                     o.Height,
                                                                     o.TaxCost,
                                                                     o.ProfitPerUnit,
                                                                     o.ProductionCost,
                                                                     o.CreatedBy,
                                                                     o.ModifiedBy,
                                                                     o.CreatedOn,
                                                                     o.ModifiedOn)).ToList();
                return oResult as dynamic;
            }
            else return new List<ProductsContract>() as dynamic;
        }

        public async ValueTask<TResponse> ReadById(Guid productId)
        {
            var oReadByIdSpec = new ReadProductsByIdSpecification(productId);
            var oResult = await _productRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                return new ProductsContract(oResult._ProductId,
                                            Guid.Empty,
                                            Guid.Empty,
                                            oResult.Name,
                                            oResult.Description,
                                            oResult.UnitPrice,
                                            oResult.Weight,
                                            oResult.Length,
                                            oResult.Width,
                                            oResult.Height,
                                            oResult.TaxCost,
                                            oResult.ProfitPerUnit,
                                            oResult.ProductionCost,
                                            oResult.CreatedBy,
                                            oResult.ModifiedBy,
                                            oResult.CreatedOn,
                                            oResult.ModifiedOn) as dynamic;

            else throw new ResultException("This object is not exit", (int)HttpStatusCode.NotFound);
        }
        public async ValueTask Update(Guid contractId, TRequest contract)
        {
            var oContract = contract as ProductsOperationsContract;
            var oReadByIdSpec = new ReadProductsByIdSpecification(contractId);
            var oResult = await _productRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
            {
                oResult.UpdateProduct(oContract!);
                await _productRepository.UpdateAsync(oResult);
            }

            else throw new ResultException("This object is not exit", (int)HttpStatusCode.NotFound);
        }

        public async ValueTask<List<TResponse>> ReadByParentId(Guid parentContractId)
        {
            var oReadCategoriesByIdSpecification = new ReadProductsByCategoryIdSpecification(parentContractId);
            var oCategoryResult = await _categoryRepository.FirstOrDefaultAsync(oReadCategoriesByIdSpecification);
            if (oCategoryResult != null) 
            {
                var oProducts = oCategoryResult.Products;
                var oResult = oProducts.Select(o => new ProductsContract(o._ProductId,
                                                                         oCategoryResult._CategoryId,
                                                                         Guid.Empty,
                                                                         o.Name,
                                                                         o.Description,
                                                                         o.UnitPrice,
                                                                         o.Weight,
                                                                         o.Length,
                                                                         o.Width,
                                                                         o.Height,
                                                                         o.TaxCost,
                                                                         o.ProfitPerUnit,
                                                                         o.ProductionCost)).ToList();
                return oResult as dynamic;
            }

            return new List<ProductsContract>() as dynamic;
        }

        public async ValueTask<TResponse> ReadSingleByParentId(Guid contractId, Guid parentContractId)
        {
            var oReadSingleProductByCategoryIdSpecification = new ReadSingleProductByCategoryIdSpecification(contractId, parentContractId);
            var oCategoryResult = await _categoryRepository.FirstOrDefaultAsync(oReadSingleProductByCategoryIdSpecification);
            if (oCategoryResult != null)
            {
                if(oCategoryResult.Products == null || oCategoryResult.Products.Count == 0)
                    throw new ResultException("This object is not exit", (int)HttpStatusCode.NotFound);

                var oProduct = oCategoryResult.Products.FirstOrDefault();
                var oResult = new ProductsContract(oProduct!._ProductId,
                                                   oCategoryResult._CategoryId,
                                                   Guid.Empty,
                                                   oProduct.Name,
                                                   oProduct.Description,
                                                   oProduct.UnitPrice,
                                                   oProduct.Weight,
                                                   oProduct.Length,
                                                   oProduct.Width,
                                                   oProduct.Height,
                                                   oProduct.TaxCost,
                                                   oProduct.ProfitPerUnit,
                                                   oProduct.ProductionCost);
                return oResult as dynamic;
            }

            return default!;
        }

        public async ValueTask UpdateParentId(Guid contractId, Guid parentContractId)
        {
            var oReadByIdSpec = new ReadProductsByIdSpecification(contractId);
            var oResult = await _productRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult == null)
                throw new ResultException("This product object is not exit", (int)HttpStatusCode.NotFound);

            var oReadParentByIdSpec = new ReadCategoriesByIdSpecification(parentContractId);
            var oParentResult = await _categoryRepository.FirstOrDefaultAsync(oReadParentByIdSpec);
            if(oParentResult == null)
                throw new ResultException("This category object is not exit", (int)HttpStatusCode.NotFound);

            oResult.SetCategory(oParentResult);
            await _productRepository.UpdateAsync(oResult);
        }
    }
}
