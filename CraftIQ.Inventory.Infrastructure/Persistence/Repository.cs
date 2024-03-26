using CraftIQ.Inventory.Core.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Persistence;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async ValueTask<TEntity> GetByIdAsync(object id) => await _dbSet.FindAsync(id);
        

    public async ValueTask<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
        

    public IEnumerable<TEntity> Include(Expression<Func<TEntity, bool>> predicate) => _dbSet.Include(predicate);
        

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate);


    public async ValueTask<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.SingleAsync(predicate);


    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async ValueTask AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async ValueTask Remove(object id)
    {
        var entity = await _dbSet.FindAsync(id);
        _dbSet.Remove(entity);
    }

    public async ValueTask RemoveRangeAsync(IEnumerable<object> ids)
    {
        var entities = await _dbSet.FindAsync(ids);
        _dbSet.RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async ValueTask<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

}


