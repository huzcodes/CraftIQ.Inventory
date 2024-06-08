using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System.Net;
using CraftIQ.Inventory.Core.Entities.Inventories.Specifications;

namespace CraftIQ.Inventory.Services.InventoryImplementations
{
    public class InventoryServices<TRequest, TResponse>(IRepository<Core.Entities.Inventories.Inventory> repository) : IGenericServices<TRequest, TResponse>
    {
        IRepository<Core.Entities.Inventories.Inventory> _repository = repository;
        public async ValueTask<TRequest> Create(TRequest contract)
        {
            var oContract = contract as InventoriesOperationsContract;
            var oData = new Core.Entities.Inventories.Inventory(oContract!.Quantity,
                                                                oContract.Reorderlevel,
                                                                oContract.Location,
                                                                oContract.LastUpdated,
                                                                oContract.Name);
            var oResult = await _repository.AddAsync(oData);
            if (oResult == null)
                return default!;

            oContract._InventoryId = oResult._InventoryId;
            return oContract as dynamic;
        }

        public async ValueTask Delete(Guid contractId)
        {
            var oReadByIdSpec = new ReadInventoryByIdSpecification(contractId);
            var oResult = await _repository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                await _repository.DeleteAsync(oResult);
            else throw new ResultException("You can't delete object that is not exit.", (int)HttpStatusCode.Forbidden);
        }

        public async ValueTask<List<TResponse>> Read()
        {
            var oReadSpec = new ReadInventorySpecification();
            var oData = await _repository.ListAsync(oReadSpec);
            if (oData != null && oData.Count > 0)
            {
                var oResult = oData.Select(o => new InventoriesContract(o._InventoryId,
                                                                        o.Name,
                                                                        o.Quantity,
                                                                        o.Reorderlevel,
                                                                        o.Location,
                                                                        o.CreatedBy,
                                                                        o.ModifiedBy,
                                                                        o.CreatedOn,
                                                                        o.ModifiedOn)).ToList();
                return oResult as dynamic;
            }
            else return new List<InventoriesContract>() as dynamic;
        }

        public async ValueTask<TResponse> ReadById(Guid contractId)
        {
            var oReadByIdSpec = new ReadInventoryByIdSpecification(contractId);
            var oResult = await _repository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                return new InventoriesContract(oResult._InventoryId,
                                               oResult.Name,
                                               oResult.Quantity,
                                               oResult.Reorderlevel,
                                               oResult.Location,
                                               oResult.CreatedBy,
                                               oResult.ModifiedBy,
                                               oResult.CreatedOn,
                                               oResult.ModifiedOn) as dynamic;

            else throw new ResultException("This object is not exit", (int)HttpStatusCode.NotFound);
        }

        public async ValueTask Update(Guid contractId, TRequest contract)
        {
            var oContract = contract as InventoriesOperationsContract;
            var oReadByIdSpec = new ReadInventoryByIdSpecification(contractId);
            var oResult = await _repository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
            {
                oResult.UpdateInventory(oContract!);
                await _repository.UpdateAsync(oResult);
            }

            else throw new ResultException("This object is not exit", (int)HttpStatusCode.NotFound);
        }

        public ValueTask<List<TResponse>> ReadByParentId(Guid parentContractId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TResponse> ReadSingleByParentId(Guid contractId, Guid parentContractId)
        {
            throw new NotImplementedException();
        }

        public ValueTask UpdateParentId(Guid contractId, Guid parentContractId)
        {
            throw new NotImplementedException();
        }
    }
}
