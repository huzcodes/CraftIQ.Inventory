using CraftIQ.Inventory.Core.Interfaces;

namespace CraftIQ.Inventory.Services.ProductsImplementations
{
    public class ProductsServices<TRequest, TResponse> : IGenericServices<TRequest, TResponse>
    {
        public ValueTask<TRequest> Create(TRequest contract)
        {
            throw new NotImplementedException();
        }

        public ValueTask Delete(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<TResponse>> Read()
        {
            throw new NotImplementedException();
        }

        public ValueTask<TResponse> ReadById(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public ValueTask Update(Guid categoryId, TRequest contract)
        {
            throw new NotImplementedException();
        }
    }
}
