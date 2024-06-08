using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Inventories.Update
{
    public class UpdateInventoryRequest
    {
        [FromRoute]
        public Guid inventoryId { get; set; }
        [FromBody]
        public InventoryBody Inventory { get; set; } = null!;
    }

    public class InventoryBody
    {
        public int Quantity { get; set; }
        public int Reorderlevel { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

}
