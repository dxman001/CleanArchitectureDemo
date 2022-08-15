using Application.Interfaces;
using Persistance.DataBase;
using System.Linq.Expressions;

namespace Persistance.Repository;

public class QueryRepositoryBase<TEntity> : IQueryRepositoryBase<TEntity> where TEntity : class
{
    protected readonly IAppDbContext _context;

    public QueryRepositoryBase(IAppDbContext context)
    {
        _context = context;
    }

    public virtual IQueryable<TEntity> GetAll() => 
        _context.Set<TEntity>();
    
    public virtual async Task<TEntity?> GetById(int id) => 
        await _context.Set<TEntity>().FindAsync(id);

    public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression) =>
        _context.Set<TEntity>().Where(expression);
}
