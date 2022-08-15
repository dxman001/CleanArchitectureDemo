namespace Persistance.CommandHandlers.Customers;

using Application.Customers;
using Application.Customers.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, int>
{
    private readonly ICustomerCommandRepository _commandRepository;

    public AddCustomerCommandHandler(ICustomerCommandRepository commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task<int> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
        var result = await _commandRepository.Add(request.Customer.MapToEntity());
        _commandRepository.Persist();
        return result.Id;
    }
}
