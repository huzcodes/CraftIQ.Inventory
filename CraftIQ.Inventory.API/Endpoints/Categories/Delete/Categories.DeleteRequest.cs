using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Delete
{
    public class CategoriesDeleteRequest
    {
        [FromRoute]
        public Guid categoryId { get; set; }
    }
}
