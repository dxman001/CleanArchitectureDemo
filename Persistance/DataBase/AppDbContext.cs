namespace Persistance.DataBase; 
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext,IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public async Task<int> ExecuteSqlRawAsync(string query, CancellationToken cancellationToken) =>
        await base.Database.ExecuteSqlRawAsync(query, cancellationToken);
            
    public async Task<int> ExecuteSqlRawAsync(string query) =>
        await ExecuteSqlRawAsync(query, CancellationToken.None);

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    var entitiesAssembly = typeof(IEntity).Assembly;

    //    modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
    //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntity).Assembly);
    //    modelBuilder.AddPluralizingTableNameConvention();
    //}

}
