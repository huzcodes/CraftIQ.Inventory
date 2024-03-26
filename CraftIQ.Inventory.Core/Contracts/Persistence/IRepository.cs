using System.Linq.Expressions;

namespace CraftIQ.Inventory.Core.Contracts.Persistence;

public interface IRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity> GetByIdAsync(object id);
    ValueTask<IEnumerable<TEntity>> GetAllAsync();
    IEnumerable<TEntity> Include(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    ValueTask<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask AddRangeAsync(IEnumerable<TEntity> entities);
    ValueTask Remove(object id);
    ValueTask RemoveRangeAsync(IEnumerable<object> ids);
    void Update(TEntity entity);
    ValueTask<int> SaveAsync();
}

