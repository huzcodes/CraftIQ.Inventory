namespace CraftIQ.Inventory.API.Endpoints.Categories
{
    public class CreateCategoryRequest
    {
        public const string Route = "/category";
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
