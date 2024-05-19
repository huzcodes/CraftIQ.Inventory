using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Read.ById
{
    public class ReadProductByIdRequest
    {
        [FromRoute]
        public Guid productId { get; set; }
    }
}
