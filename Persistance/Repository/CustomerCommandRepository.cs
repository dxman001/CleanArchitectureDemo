namespace Persistance.Repository; 
using Application.Interfaces;
using Domain.Entities;
using Persistance.DataBase;

public class CustomerCommandRepository : CommandRepositoryBase<Customer>, ICustomerCommandRepository
{
    public CustomerCommandRepository(IAppDbContext context) : base(context)
    {
    }
}
