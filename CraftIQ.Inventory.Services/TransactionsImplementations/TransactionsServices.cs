using CraftIQ.Inventory.Core.Entities.Transactions;
using CraftIQ.Inventory.Core.Entities.Transactions.Specifications;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.Transactions;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System.Net;

namespace CraftIQ.Inventory.Services.TransactionsImplementations
{
    public class TransactionsServices<TRequest, TResponse>
         (IRepository<Transaction> transactionRepository) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<Transaction> _transactionRepository = transactionRepository;

        public async ValueTask<TRequest> Create(TRequest contract)
        {
            var oContract = contract as TransactionsOperationsContract;

            var oTransaction = new Transaction(oContract!.EmployeeId,
                                               oContract.TransactionDate,
                                               oContract.Quantity,
                                               oContract.TransactionType,
                                               oContract.Notes);

            var oTransactionResult = await _transactionRepository.AddAsync(oTransaction);
            if (oTransactionResult == null)
                return default!;

            oContract._TransactionId = oTransactionResult._TransactionId;
            return oContract as dynamic;
        }

        public async ValueTask Delete(Guid transactionId)
        {
            var oReadByIdSpec = new ReadTransactionsByIdSpecification(transactionId);
            var oResult = await _transactionRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                await _transactionRepository.DeleteAsync(oResult);
            else throw new ResultException("You can't delete an object that does not exist.", (int)HttpStatusCode.Forbidden);
        }

        public async ValueTask<List<TResponse>> Read()
        {
            var oReadSpec = new ReadTransactionsSpecification();
            var oData = await _transactionRepository.ListAsync(oReadSpec);
            if (oData != null && oData.Count > 0)
            {
                var oResult = oData.Select(o => new TransactionsContract(o._TransactionId,
                                                                         o.EmployeeId,
                                                                         o.TransactionDate,
                                                                         o.Quantity,
                                                                         o.TransactionType,
                                                                         o.Notes,
                                                                         o.CreatedBy,
                                                                         o.ModifiedBy,
                                                                         o.CreatedOn,
                                                                         o.ModifiedOn)).ToList();
                return oResult as dynamic;
            }
            else return new List<TransactionsContract>() as dynamic;
        }

        public async ValueTask<TResponse> ReadById(Guid transactionId)
        {
            var oReadByIdSpec = new ReadTransactionsByIdSpecification(transactionId);
            var oResult = await _transactionRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                return new TransactionsContract(oResult._TransactionId,
                                                oResult.EmployeeId,
                                                oResult.TransactionDate,
                                                oResult.Quantity,
                                                oResult.TransactionType,
                                                oResult.Notes,
                                                oResult.CreatedBy,
                                                oResult.ModifiedBy,
                                                oResult.CreatedOn,
                                                oResult.ModifiedOn) as dynamic;

            else throw new ResultException("This object does not exist", (int)HttpStatusCode.NotFound);
        }

        public async ValueTask Update(Guid contractId, TRequest contract)
        {
            var oContract = contract as TransactionsOperationsContract;
            var oReadByIdSpec = new ReadTransactionsByIdSpecification(contractId);
            var oResult = await _transactionRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
            {
                oResult.UpdateTransaction(oContract!);
                await _transactionRepository.UpdateAsync(oResult);
            }
            else throw new ResultException("This object does not exist", (int)HttpStatusCode.NotFound);
        }

        public ValueTask UpdateParentId(Guid contractId, Guid parentContractId)
        {
            throw new NotImplementedException();
        }
        public ValueTask<List<TResponse>> ReadByParentId(Guid parentContractId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TResponse> ReadSingleByParentId(Guid contractId, Guid parentContractId)
        {
            throw new NotImplementedException();
        }
    }

}
