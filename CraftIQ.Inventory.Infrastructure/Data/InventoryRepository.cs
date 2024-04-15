using huzcodes.Persistence.Implementations.EfRepository;

namespace CraftIQ.Inventory.Infrastructure.Data
{
    public class InventoryRepository<TEntity> : HuzcodesRepository<TEntity> where TEntity : class
    {
        public InventoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
