namespace Application.Interfaces;

public interface ICommandRepositoryBase<TEntity> where TEntity : class
{
    Task<TEntity> Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    TEntity Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    int Persist();
}
