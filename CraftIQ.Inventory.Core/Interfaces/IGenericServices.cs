namespace CraftIQ.Inventory.Core.Interfaces
{
    public interface IGenericServices<TRequest, TResponse>
    {
        ValueTask<TRequest> CreateCategory(TRequest contract);
        ValueTask<List<TResponse>> ReadCategories();
        ValueTask<TResponse> ReadCategoryById(Guid categoryId);
        ValueTask UpdateCategory(Guid categoryId, TRequest contract);
        ValueTask DeleteCategory(Guid categoryId);
    }
}
