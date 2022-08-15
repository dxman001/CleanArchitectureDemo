namespace Application.Interfaces; 
using Microsoft.EntityFrameworkCore;

public interface IAppDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    int SaveChanges();
    Task<int> ExecuteSqlRawAsync(string query, CancellationToken cancellationToken);
    Task<int> ExecuteSqlRawAsync(string query);
}