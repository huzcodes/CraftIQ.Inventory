using CraftIQ.Inventory.Core.Domains.Common;

namespace CraftIQ.Inventory.Core.Domains.DB;
public class Category : BaseEntity
    {
        public Guid _CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // relation with products
        public List<Product> Products { get; set; } = new();
    }

