namespace Persistance;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.DataBase;
using Persistance.Repository;
using System.Reflection;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration) =>
        services
        .AddMediatR(Assembly.GetExecutingAssembly())
        .AddDbContext<IAppDbContext, AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ReadOnlyDB")))
        .AddScoped<IAppDbContext, AppDbContext>()
        .AddTransient(typeof(IQueryRepositoryBase<>), typeof(QueryRepositoryBase<>))
        .AddTransient(typeof(ICommandRepositoryBase<>), typeof(CommandRepositoryBase<>))
        .AddTransient<ICustomerQueryRepository, CustomerQueryRepository>()
        .AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();   
}
