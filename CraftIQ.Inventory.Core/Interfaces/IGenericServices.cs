namespace CraftIQ.Inventory.Core.Interfaces
{
    public interface IGenericServices<TRequest, TResponse>
    {
        ValueTask<TRequest> Create(TRequest contract);
        ValueTask<List<TResponse>> Read();
        ValueTask<TResponse> ReadById(Guid categoryId);
        ValueTask Update(Guid categoryId, TRequest contract);
        ValueTask Delete(Guid categoryId);
    }
}
