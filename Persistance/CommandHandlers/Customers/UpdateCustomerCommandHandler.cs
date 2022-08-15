namespace Persistance.CommandHandlers.Customers;

using Application.Customers;
using Application.Customers.Commands;
using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly ICustomerCommandRepository _commandRepository;
    private readonly ICustomerQueryRepository _queryRepository;
    public UpdateCustomerCommandHandler(ICustomerCommandRepository commandRepository, ICustomerQueryRepository queryRepository)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
    }

    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
        var customer = await _queryRepository.GetById(request.Customer.Id);
        _commandRepository.Update(request.Customer.MapToEntity(customer));
        _commandRepository.Persist();
        return true;
    }
}
