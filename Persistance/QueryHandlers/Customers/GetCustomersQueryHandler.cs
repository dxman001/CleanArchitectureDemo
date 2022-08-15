namespace Persistance.QueryHandlers.Customers;
using Application.Customers;
using Application.Customers.Queries;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerModel>>
{
    private readonly ICustomerQueryRepository _queryRepository;

    public GetCustomersQueryHandler(ICustomerQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<List<CustomerModel>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
       var customers = await _queryRepository.GetAll().ToListAsync(cancellationToken);
       return customers.Select(e=>e.MapToModel()).ToList();
      
    }
}
