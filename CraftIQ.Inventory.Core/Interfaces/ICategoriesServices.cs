using CraftIQ.Inventory.Shared.Contracts.Categories;

namespace CraftIQ.Inventory.Core.Interfaces
{
    public interface ICategoriesServices
    {
        ValueTask<CategoriesOperationsContract> CreateCategory(CategoriesOperationsContract contract);
        ValueTask<List<CategoriesContract>> ReadCategories();
        ValueTask<CategoriesContract> ReadCategoryById(Guid categoryId);
        ValueTask UpdateCategory(Guid categoryId, CategoriesOperationsContract contract);
        ValueTask DeleteCategory(Guid categoryId);
    }
}
