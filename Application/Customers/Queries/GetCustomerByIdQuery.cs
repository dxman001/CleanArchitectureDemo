namespace Application.Customers.Queries;
using MediatR;

public class GetCustomerByIdQuery : IRequest<CustomerModel>
{
    public int Id { get; set; }
}
