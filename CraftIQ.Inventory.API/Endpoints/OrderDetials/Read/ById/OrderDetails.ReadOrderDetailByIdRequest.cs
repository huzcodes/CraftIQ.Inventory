using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.Inventory.API.Endpoints.OrderDetials.Read.ById
{
    public class ReadOrderDetailByIdRequest
    {
        [FromRoute]
        public Guid orderDetailId { get; set; }
    }

}
