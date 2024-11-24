using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketService.Application.Command;
using TicketService.Application.Dto;
using TicketService.Application.Query;

namespace TicketService.Api.Controllers;

[ApiController]
[Route("ticket")]
public class TicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetTicketDto>>> GetAllTickets()
    {
        var query = new GetAllTicketsQuery();
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<GetTicketDto>> GetTicket(Guid id)
    {
        var query = new GetTicketByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        
        return result != null ? Ok(result) : NotFound();
    }
    
    [HttpPost("create")]
    public async Task<ActionResult<Guid>> CreateTicket(CreateTicketDto request)
    {
        var query = new AddTicketCommand { Dto = request };
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    [HttpPatch("update")]
    public async Task<ActionResult<bool>> UpdateTicket(UpdateTicketDto request)
    {
        var query = new UpdateTicketCommand { Dto = request };
        var result = await _mediator.Send(query);
        
        return result ? Ok() : NotFound();
    }
    
    [HttpDelete("delete/{id:Guid}")]
    public async Task<ActionResult<Guid>> DeleteTicket(Guid id)
    {
        var query = new RemoveTicketCommand() { Id = id };
        var result = await _mediator.Send(query);
        
        return result ? Ok() : NotFound();
    }

    [HttpPatch]
    public async Task<ActionResult<bool>> ChangeBoard(MoveTicketDto request)
    {
        var query = new MoveTicketCommand() { Dto = request };
        var result = await _mediator.Send(query);
        
        return result ? Ok() : NotFound();
    }
}