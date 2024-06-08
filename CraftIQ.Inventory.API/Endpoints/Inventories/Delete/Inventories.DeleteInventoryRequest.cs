using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.Inventories.Delete
{
    public class DeleteInventoryRequest
    {
        [FromRoute]
        public Guid inventoryId { get; set; }
    }

}
