namespace CraftIQ.Inventory.Core.Interfaces
{
    public interface IGenericServices<TRequest, TResponse>
    {
        ValueTask<TRequest> Create(TRequest contract);
        ValueTask<List<TResponse>> Read();
        ValueTask<List<TResponse>> ReadByParentId(Guid parentContractId);
        ValueTask<TResponse> ReadById(Guid contractId);
        ValueTask<TResponse> ReadSingleByParentId(Guid contractId, Guid parentContractId);
        ValueTask Update(Guid contractId, TRequest contract);
        ValueTask UpdateParentId(Guid contractId, Guid parentContractId);
        ValueTask Delete(Guid contractId);
    }
}
