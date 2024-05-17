using CraftIQ.Inventory.Shared.Contracts.Categories;

namespace CraftIQ.Inventory.API.Endpoints.Categories.Read
{
    public class ReadCategoriesResponse
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public ReadCategoriesResponse(CategoriesContract contract)
        {
            CategoryId = contract.CategoryId;
            Name = contract.Name;
            Description = contract.Description;
            CreatedBy = contract.CreatedBy;
            CreatedOn = contract.CreatedOn;
            ModifiedBy = contract.ModifiedBy;
            ModifiedOn = contract.ModifiedOn;
        }
    }
}
