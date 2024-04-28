namespace CraftIQ.Inventory.Shared.Contracts.Categories
{
    public class CategoriesContract
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public CategoriesContract(Guid categoryId,
                                  string name,
                                  string description,
                                  Guid createdBy,
                                  Guid modifiedBy,
                                  DateTimeOffset createdOn,
                                  DateTimeOffset modifiedOn)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            ModifiedBy = modifiedBy;
            ModifiedOn = modifiedOn;
        }
    }
}
