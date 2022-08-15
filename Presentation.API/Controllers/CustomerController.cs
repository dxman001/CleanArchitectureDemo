namespace Presentation.API.Controllers;

using Application.Customers;
using Application.Customers.Commands;
using Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Dtos;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
   
    protected IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse> GetAll() =>
        new ApiResponse(await _mediator.Send(new GetCustomersQuery()));
    
    [HttpGet("Id")]
    public async Task<ApiResponse> GetById([FromQuery] int id) =>
        new ApiResponse(await _mediator.Send(new GetCustomerByIdQuery { Id = id }));
    
    [HttpPost("Add")]
    public async Task<ApiResponse> Add([FromBody] AddCustomerCommand command) =>
        new ApiResponse(await _mediator.Send(command));
    
    [HttpPost("Update")]
    public async Task<ApiResponse> Update([FromBody] UpdateCustomerCommand command) =>
        new ApiResponse(await _mediator.Send(command));
    
}
