namespace CraftIQ.Inventory.API.Endpoints.Inventories.Create
{
    public class CreateInventoryRequest
    {
        public int Quantity { get; set; }
        public int Reorderlevel { get; set; }
        public string Location { get; set; } = string.Empty;

        public CreateInventoryRequest(int quantity, int reorderlevel, string location)
        {
            Quantity = quantity;
            Reorderlevel = reorderlevel;
            Location = location;
        }
    }

}
