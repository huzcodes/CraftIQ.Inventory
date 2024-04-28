using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Update
{
    public class UpdateCategoriesRequest
    {
        [FromRoute]
        public Guid categoryId { get; set; }
        [FromBody]
        public Body Category { get; set; } = new();
    }

    public class Body
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
