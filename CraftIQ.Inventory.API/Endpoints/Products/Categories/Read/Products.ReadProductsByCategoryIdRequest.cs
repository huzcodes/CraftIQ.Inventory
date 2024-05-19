using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Products.Categories.Read
{
    public class ReadProductsByCategoryIdRequest
    {
        [FromRoute]
        public Guid categoryId { get; set; }
    }
}
