using CraftIQ.Inventory.Core.Domains.Common;

namespace CraftIQ.Inventory.Core.Domains.DB;
public class Inventory : BaseEntity
{
    public Inventory() { } // for entity framework

    public Guid _InventoryId { get; set; }
    public int Quantity { get; set; }
    public int Reorderlevel { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTimeOffset LastUpdated { get; set; }

    // relation with products
    public List<Product> Products { get; set; } = new();
}

