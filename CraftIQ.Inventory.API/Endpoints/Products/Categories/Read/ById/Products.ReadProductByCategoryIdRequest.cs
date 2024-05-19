using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Categories.Read.ById
{
    public class ReadProductByCategoryIdRequest
    {
        [FromRoute]
        public Guid productId { get; set; }
        [FromRoute]
        public Guid categoryId { get; set; }
    }
}
