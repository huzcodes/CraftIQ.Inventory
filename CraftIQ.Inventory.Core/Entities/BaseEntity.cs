namespace CraftIQ.Inventory.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
