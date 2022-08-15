namespace Application.Customers.Commands;
using MediatR;

public class AddCustomerCommand : IRequest<int>
{
   public CustomerModel Customer { get; set; }
}


