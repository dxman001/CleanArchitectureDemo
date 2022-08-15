namespace Persistance.Repository; 
using Application.Interfaces;
using Persistance.DataBase;

public class CommandRepositoryBase<TEntity> : ICommandRepositoryBase<TEntity> where TEntity : class
{
    protected readonly IAppDbContext _context;

    public CommandRepositoryBase(IAppDbContext context)
    {
        _context = context;
    }
    public async Task<TEntity> Add(TEntity entity)
    {
        var result = await _context.Set<TEntity>().AddAsync(entity);
        return result.Entity;
    }

    public void AddRange(IEnumerable<TEntity> entities) =>
        _context.Set<TEntity>().AddRange(entities);

    public TEntity Update(TEntity entity) =>
        _context.Set<TEntity>().Update(entity).Entity;

    public void UpdateRange(IEnumerable<TEntity> entities) =>
        _context.Set<TEntity>().UpdateRange(entities);

    public void Remove(TEntity entity) =>
         _context.Set<TEntity>().Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entities) =>
        _context.Set<TEntity>().RemoveRange(entities);

    public int Persist() =>
        _context.SaveChanges();

}
