using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Update
{
    public class UpdateCategoriesRequest
    {
        [FromRoute]
        public Guid categoryId { get; set; }
        [FromBody]
        public CategoryBody Category { get; set; } = new();
    }

    public class CategoryBody
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
