using CraftIQ.Inventory.API.Endpoints.Products.Read;
using CraftIQ.Inventory.Shared.Contracts.Products;

namespace CraftIQ.Inventory.API.Endpoints.Products.Categories.Read
{
    public class ReadProductsByCategoryIdResponse : ReadProductsResponse
    {
        public Guid CategoryId { get; set; }
        public ReadProductsByCategoryIdResponse(ProductsContract contract) : base(contract)
        {
            CategoryId = contract._CategoryId;
        }
    }
}
