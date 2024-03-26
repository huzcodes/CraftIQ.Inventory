using System.ComponentModel.DataAnnotations;

namespace CraftIQ.Inventory.Core.Domains.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid ModifiedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }



    // https://www.youtube.com/watch?v=DI9fTuH60To
    // Handling Concurrency: Practical Tips for EF Core Developers
    [ConcurrencyCheck]
    public Guid Version { get; set; }
}
