using CraftIQ.Inventory.Core.Entities.OrderDetails.Specifications;
using CraftIQ.Inventory.Core.Entities.OrderDetails;
using CraftIQ.Inventory.Core.Entities.Orders;
using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System.Net;
using CraftIQ.Inventory.Core.Entities.Orders.Specifications;
using CraftIQ.Inventory.Core.Entities.Products.Specifications;

namespace CraftIQ.Inventory.Services.OrderDetailsImplementations
{
    public class OrderDetailsServices<TRequest, TResponse>
         (IRepository<Order> orderRepository,
          IRepository<Product> productRepository,
          IRepository<OrderDetail> orderDetailRepository) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<Order> _orderRepository = orderRepository;
        private readonly IRepository<Product> _productRepository = productRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository = orderDetailRepository;

        public async ValueTask<TRequest> Create(TRequest contract)
        {
            var oContract = contract as OrderDetailsOperationsContract;

            // Order
            var oOrderSpec = new ReadOrdersByIdSpecification(oContract!.OrderId);
            var oOrder = await _orderRepository.FirstOrDefaultAsync(oOrderSpec);
            if (oOrder == null)
                throw new ResultException("Order does not exist!", (int)HttpStatusCode.NotFound);

            // Product
            var oProductSpec = new ReadProductsByIdSpecification(oContract.ProductId);
            var oProduct = await _productRepository.FirstOrDefaultAsync(oProductSpec);
            if (oProduct == null)
                throw new ResultException("Product does not exist!", (int)HttpStatusCode.NotFound);

            var oOrderDetail = new OrderDetail(oContract.Quantity,
                                               oContract.TotalPrice);

            oOrderDetail.SetOrder(oOrder);
            oOrderDetail.SetProduct(oProduct);

            var oOrderDetailResult = await _orderDetailRepository.AddAsync(oOrderDetail);
            if (oOrderDetailResult == null)
                return default!;

            oContract._OrderDetailId = oOrderDetailResult._OrderDetailId;
            return oContract as dynamic;
        }

        public async ValueTask Delete(Guid orderDetailId)
        {
            var oReadByIdSpec = new ReadOrderDetailsByIdSpecification(orderDetailId);
            var oResult = await _orderDetailRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                await _orderDetailRepository.DeleteAsync(oResult);
            else throw new ResultException("You can't delete an object that does not exist.", (int)HttpStatusCode.Forbidden);
        }

        public async ValueTask<List<TResponse>> Read()
        {
            var oReadSpec = new ReadOrderDetailsSpecification();
            var oData = await _orderDetailRepository.ListAsync(oReadSpec);
            if (oData != null && oData.Count > 0)
            {
                var oResult = oData.Select(o => new OrderDetailsContract(o._OrderDetailId,
                                                                         o.Quantity,
                                                                         o.TotalPrice,
                                                                         o.Order._OrderId,
                                                                         o.Product._ProductId,
                                                                         o.CreatedBy,
                                                                         o.ModifiedBy,
                                                                         o.CreatedOn,
                                                                         o.ModifiedOn)).ToList();
                return oResult as dynamic;
            }
            else return new List<OrderDetailsContract>() as dynamic;
        }

        public async ValueTask<TResponse> ReadById(Guid orderDetailId)
        {
            var oReadByIdSpec = new ReadOrderDetailsByIdSpecification(orderDetailId);
            var oResult = await _orderDetailRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                return new OrderDetailsContract(oResult._OrderDetailId,
                                                oResult.Quantity,
                                                oResult.TotalPrice,
                                                oResult.Order._OrderId,
                                                oResult.Product._ProductId,
                                                oResult.CreatedBy,
                                                oResult.ModifiedBy,
                                                oResult.CreatedOn,
                                                oResult.ModifiedOn) as dynamic;

            else throw new ResultException("This object does not exist", (int)HttpStatusCode.NotFound);
        }
        public async ValueTask Update(Guid contractId, TRequest contract)
        {
            var oContract = contract as OrderDetailsOperationsContract;
            var oReadByIdSpec = new ReadOrderDetailsByIdSpecification(contractId);
            var oResult = await _orderDetailRepository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
            {
                oResult.UpdateOrderDetail(oContract!);
                await _orderDetailRepository.UpdateAsync(oResult);
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
