using MediatR;
namespace Application.Customers.Commands;

public class UpdateCustomerCommand : IRequest<bool>
{
    public CustomerModel Customer { get; set; }
}
