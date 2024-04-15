namespace CraftIQ.Inventory.Core.Entities
{
    public class Category : BaseEntity
    {
        public Guid _CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // relation with products
        public List<Product> Products { get; set; } = new();

        public Category(){ } // for EF core

        public Category(string name, string description)
        {
            _CategoryId = Guid.NewGuid();
            Name = name;
            Description = description;
            CreatedBy = Guid.Empty;
            CreatedOn = DateTimeOffset.Now;
            ModifiedBy = Guid.Empty;
            ModifiedOn = DateTimeOffset.Now;
        }
    }
}
