namespace CraftIQ.Inventory.Shared.Contracts.Inventories
{
    public class InventoriesOperationsContract
    {
        public Guid _InventoryId { get; set; }
        public int Quantity { get; set; }
        public int Reorderlevel { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTimeOffset LastUpdated { get; set; }

        public InventoriesOperationsContract(Guid inventoryId,
                                             int quantity,
                                             int reorderlevel,
                                             string location)
        {
            _InventoryId = inventoryId;
            Quantity = quantity;
            Reorderlevel = reorderlevel;
            Location = location;
            LastUpdated = DateTimeOffset.Now;
        }
    }
}
