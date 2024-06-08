using CraftIQ.Inventory.Core.Entities.Products;
using CraftIQ.Inventory.Shared.Contracts.Inventories;

namespace CraftIQ.Inventory.Core.Entities.Inventories
{
    public class Inventory : BaseEntity
    {
        public Inventory() { }// for entity framework

        public Guid _InventoryId { get; set; }
        public int Quantity { get; set; }
        public int Reorderlevel { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTimeOffset LastUpdated { get; set; }

        // relation with products
        public List<Product> Products { get; set; } = new();

        public Inventory(int quantity,
                         int reorderlevel,
                         string location,
                         DateTimeOffset lastUpdated)
        {
            _InventoryId = Guid.NewGuid();
            Quantity = quantity;
            Reorderlevel = reorderlevel;
            Location = location;
            LastUpdated = lastUpdated;
        }


        public void UpdateInventory(InventoriesOperationsContract inventory)
        {
            ModifiedOn = DateTimeOffset.Now;
            LastUpdated = DateTimeOffset.Now;
            Quantity = inventory.Quantity == 0 ? this.Quantity : inventory.Quantity;
            Reorderlevel = inventory.Reorderlevel == 0 ? this.Reorderlevel : inventory.Reorderlevel;
            Location = string.IsNullOrEmpty(inventory.Location) ? this.Location : inventory.Location;
        }
    }
}
