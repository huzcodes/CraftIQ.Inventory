using System.ComponentModel.DataAnnotations;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Create
{
    public class CreateCategoriesRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
