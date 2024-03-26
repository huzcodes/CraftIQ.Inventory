using CraftIQ.Inventory.Core.Domains.Common;

namespace CraftIQ.Inventory.Core.Domains.DB;
public class OrderDetail : BaseEntity
{
    public Guid _OrderDetailId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    //relation with orders
    public int OrderId { get; set; }
    public Order Order { get; set; } = new();

    //relation with products
    public int ProductId { get; set; }
    public Product Product { get; set; } = new();
}

