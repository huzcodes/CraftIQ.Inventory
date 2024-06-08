namespace CraftIQ.Inventory.API.Endpoints.Inventories.Create
{
    public class CreateInventoryRequest
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Reorderlevel { get; set; }
        public string Location { get; set; } = string.Empty;

        public CreateInventoryRequest(string name, int quantity, int reorderlevel, string location)
        {
            Name = name;
            Quantity = quantity;
            Reorderlevel = reorderlevel;
            Location = location;
        }
    }

}
