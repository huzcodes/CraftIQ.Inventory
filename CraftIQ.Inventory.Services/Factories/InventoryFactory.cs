﻿using CraftIQ.Inventory.Core.Entities.Categories;
using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Core.Entities.Transactions;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Services.CategoriesImplementations;
using CraftIQ.Inventory.Services.InventoryImplementations;
using CraftIQ.Inventory.Services.ProductsImplementations;
using CraftIQ.Inventory.Services.TransactionsImplementations;
using huzcodes.Persistence.Interfaces.Repositories;

namespace CraftIQ.Inventory.Services.Factories
{
    public class InventoryFactory<TRequest, TResponse>(IRepository<Category> categoryRepository,
                                                       IRepository<Product> productRepository,
                                                       IRepository<Core.Entities.Inventories.Inventory> inventoryRepository,
                                                       IRepository<Transaction> transactionRepository)
    {
        private readonly IRepository<Category> _categoryRepository = categoryRepository;
        private readonly IRepository<Product> _productRepository = productRepository;
        private readonly IRepository<Core.Entities.Inventories.Inventory> _inventoryRepository = inventoryRepository;
        private readonly IRepository<Transaction> _transactionRepository = transactionRepository;
        public IGenericServices<TRequest, TResponse> Build(string key)
        {
            switch (key)
            {
                case nameof(Category):
                    return new CategoriesServices<TRequest, TResponse>(_categoryRepository);
                case nameof(Product):
                    return new ProductsServices<TRequest, TResponse>(_categoryRepository, _productRepository, _inventoryRepository, _transactionRepository);
                case nameof(Core.Entities.Inventories.Inventory):
                    return new InventoryServices<TRequest, TResponse>(_inventoryRepository);
                case nameof(Transaction):
                    return new TransactionsServices<TRequest, TResponse>(_transactionRepository);
                default: return null!;
            }
        }
    }
}
