namespace CraftIQ.Inventory.API.Endpoints.Inventories.Create
{
    public class CreateInventoryResponse
    {
        public Guid InventoryId { get; set; }

        public CreateInventoryResponse(Guid inventoryId)
        {
            InventoryId = inventoryId;
        }
    }

}
