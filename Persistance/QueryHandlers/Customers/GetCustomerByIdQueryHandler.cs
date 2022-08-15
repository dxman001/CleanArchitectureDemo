namespace Persistance.QueryHandlers.Customers;
using Application.Customers;
using Application.Customers.Queries;
using Application.Interfaces;
using MediatR;



public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerModel>
{
    private readonly ICustomerQueryRepository _queryRepository;

    public GetCustomerByIdQueryHandler(ICustomerQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async Task<CustomerModel?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
        var customer = await _queryRepository.GetById(request.Id);
        return customer?.MapToModel();

    }
}
