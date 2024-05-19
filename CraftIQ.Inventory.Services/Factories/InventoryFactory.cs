using CraftIQ.Inventory.Core.Entities.Categories;
using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Services.CategoriesImplementations;
using CraftIQ.Inventory.Services.ProductsImplementations;
using huzcodes.Persistence.Interfaces.Repositories;

namespace CraftIQ.Inventory.Services.Factories
{
    public class InventoryFactory<TRequest, TResponse>(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
    {
        private readonly IRepository<Category> _categoryRepository = categoryRepository;
        private readonly IRepository<Product> _productRepository = productRepository;
        public IGenericServices<TRequest, TResponse> Build(string key)
        {
            switch (key)
            {
                case nameof(Category):
                    return new CategoriesServices<TRequest, TResponse>(_categoryRepository);
                case nameof(Product):
                    return new ProductsServices<TRequest, TResponse>(_categoryRepository, _productRepository);
                default: return null!;
            }
        }
    }
}
