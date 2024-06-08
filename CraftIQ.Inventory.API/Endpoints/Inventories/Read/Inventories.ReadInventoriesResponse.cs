using CraftIQ.Inventory.Shared.Contracts.Inventories;

namespace CraftIQ.Inventory.API.Endpoints.Inventories.Read
{
    public class ReadInventoriesResponse
    {
        public Guid InventoryId { get; set; }
        public int Quantity { get; set; }
        public int Reorderlevel { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTimeOffset LastUpdated { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public ReadInventoriesResponse(InventoriesContract inventory)
        {
            InventoryId = inventory._InventoryId;
            Quantity = inventory.Quantity;
            Reorderlevel = inventory.Reorderlevel;
            Location = inventory.Location;
            LastUpdated = inventory.LastUpdated;
            CreatedBy = inventory.CreatedBy;
            ModifiedBy = inventory.ModifiedBy;
            CreatedOn = inventory.CreatedOn;
            ModifiedOn = inventory.ModifiedOn;
        }
    }

}
