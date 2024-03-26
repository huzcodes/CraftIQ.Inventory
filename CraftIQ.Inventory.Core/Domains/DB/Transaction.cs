using CraftIQ.Inventory.Core.Domains.Common;

namespace CraftIQ.Inventory.Core.Domains.DB;
public class Transaction : BaseEntity
{
    public Guid _TransactionId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTimeOffset TransactionDate { get; set; }
    public int Quantity { get; set; }
    public int TransactionType { get; set; }
    public string Notes { get; set; } = string.Empty;

    //relation with products
    public List<Product> Products { get; set; } = new();
}

