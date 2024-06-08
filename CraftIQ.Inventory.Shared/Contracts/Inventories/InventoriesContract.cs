namespace CraftIQ.Inventory.Shared.Contracts.Inventories
{
    public class InventoriesContract : InventoriesOperationsContract
    {
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public InventoriesContract(Guid inventoryId,
                                   string name,
                                   int quantity,
                                   int reorderlevel,
                                   string location,
                                   Guid createdBy,
                                   Guid modifiedBy,
                                   DateTimeOffset createdOn,
                                   DateTimeOffset modifiedOn) : base(inventoryId,
                                                                     name,
                                                                     quantity,
                                                                     reorderlevel,
                                                                     location)
        {
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
        }
    }
}
