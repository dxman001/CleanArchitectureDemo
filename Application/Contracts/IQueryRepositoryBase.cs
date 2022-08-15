namespace Application.Interfaces;
using System.Linq.Expressions;

public interface IQueryRepositoryBase<TEntity> where TEntity : class
{
    Task<TEntity?> GetById(int id);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
}
