namespace CraftIQ.Inventory.Shared.Contracts.Categories
{
    public class CategoriesOperationsContract
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public CategoriesOperationsContract(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
