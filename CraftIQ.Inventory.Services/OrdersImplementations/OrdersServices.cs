using CraftIQ.Inventory.Core.Entities.Orders.Specifications;
using CraftIQ.Inventory.Core.Entities.Orders;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System.Net;

namespace CraftIQ.Inventory.Services.OrdersImplementations
{
    public class OrdersServices<TRequest, TResponse>
         (IRepository<Order> orderRepository) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<Order> _orderRepository = orderRepository;

        public async ValueTask<TRequest> Create(TRequest contract)
        {
            var oContract = contract as OrdersOperationsContract;

            var oOrder = new Order(oContract!.SupplierId,
                                   oContract.TotalAmount,
                                   oContract.Status,
                                   oContract.ExpectedDeliveryDate,
                                   oContract.OrderType);

            var oOrderResult = await _orderRepository.AddAsync(oOrder);
            if (oOrderResult == null)
                return default!;

            oContract._OrderId = oOrderResult._OrderId;
            return oContract as dynamic;
        }

        public async ValueTask Delete(Guid orderId)
        {
            var oReadByIdSpec = new ReadOrdersByIdSpecification(orderId);
            var oResult = await _orderRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                await _orderRepository.DeleteAsync(oResult);
            else throw new ResultException("You can't delete an object that does not exist.", (int)HttpStatusCode.Forbidden);
        }

        public async ValueTask<List<TResponse>> Read()
        {
            var oReadSpec = new ReadOrdersSpecification();
            var oData = await _orderRepository.ListAsync(oReadSpec);
            if (oData != null && oData.Count > 0)
            {
                var oResult = oData.Select(o => new OrdersContract(o._OrderId,
                                                                   o.SupplierId,
                                                                   o.OrderDate,
                                                                   o.TotalAmount,
                                                                   o.Status,
                                                                   o.ExpectedDeliveryDate,
                                                                   o.OrderType,
                                                                   o.ReceivedDate,
                                                                   o.CreatedBy,
                                                                   o.ModifiedBy,
                                                                   o.CreatedOn,
                                                                   o.ModifiedOn)).ToList();
                return oResult as dynamic;
            }
            else return new List<OrdersContract>() as dynamic;
        }

        public async ValueTask<TResponse> ReadById(Guid orderId)
        {
            var oReadByIdSpec = new ReadOrdersByIdSpecification(orderId);
            var oResult = await _orderRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                return new OrdersContract(oResult._OrderId,
                                          oResult.SupplierId,
                                          oResult.OrderDate,
                                          oResult.TotalAmount,
                                          oResult.Status,
                                          oResult.ExpectedDeliveryDate,
                                          oResult.OrderType,
                                          oResult.ReceivedDate,
                                          oResult.CreatedBy,
                                          oResult.ModifiedBy,
                                          oResult.CreatedOn,
                                          oResult.ModifiedOn) as dynamic;

            else throw new ResultException("This object does not exist", (int)HttpStatusCode.NotFound);
        }

        public async ValueTask Update(Guid contractId, TRequest contract)
        {
            var oContract = contract as OrdersOperationsContract;
            var oReadByIdSpec = new ReadOrdersByIdSpecification(contractId);
            var oResult = await _orderRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
            {
                oResult.UpdateOrder(oContract!);
                await _orderRepository.UpdateAsync(oResult);
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
