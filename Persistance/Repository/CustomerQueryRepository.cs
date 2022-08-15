namespace Persistance.Repository;
using Application.Interfaces;
using Domain.Entities;
using Persistance.DataBase;

public class CustomerQueryRepository : QueryRepositoryBase<Customer>, ICustomerQueryRepository
{
    public CustomerQueryRepository(IAppDbContext context) : base(context)
    {
    }

}
