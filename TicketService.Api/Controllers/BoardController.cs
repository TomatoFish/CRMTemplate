using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketService.Application.Command;
using TicketService.Application.Dto;
using TicketService.Application.Query;

namespace TicketService.Api.Controllers;

[ApiController]
[Route("board")]
public class BoardController : ControllerBase
{
    private readonly IMediator _mediator;

    public BoardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetBoardDto>>> GetAllBoards()
    {
        var query = new GetAllBoardsQuery();
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<GetBoardDto>> GetBoard(Guid id)
    {
        var query = new GetBoardByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        
        return result != null ? Ok(result) : NotFound();
    }
    
    [HttpPost("create")]
    public async Task<ActionResult<Guid>> CreateBoard(CreateBoardDto request)
    {
        var query = new AddBoardCommand { Dto = request };
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    [HttpPatch("update")]
    public async Task<ActionResult<bool>> UpdateBoard(UpdateBoardDto request)
    {
        var query = new UpdateBoardCommand { Dto = request };
        var result = await _mediator.Send(query);
        
        return result ? Ok() : NotFound();
    }
    
    [HttpDelete("delete/{id:Guid}")]
    public async Task<ActionResult<Guid>> DeleteBoard(Guid id)
    {
        var query = new RemoveBoardCommand() { Id = id };
        var result = await _mediator.Send(query);
        
        return result ? Ok() : NotFound();
    }
}