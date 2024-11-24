using MediatR;
using TicketService.Application.Dto;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Command;

public class MoveTicketCommand : IRequest<bool>
{
    public MoveTicketDto Dto { get; set; }
}

public class MoveTicketCommandHandler : IRequestHandler<MoveTicketCommand, bool>
{
    private readonly ITicketRepository _repository;

    public MoveTicketCommandHandler(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(MoveTicketCommand request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetByIdAsync(request.Dto.Id);

        if (model == null) return false;
        if (model.BoardId == request.Dto.BoardId) return false;
        
        model.UpdateDateTime = DateTime.UtcNow;
        model.BoardId = request.Dto.BoardId;
            
        await _repository.UpdateAsync(model);

        _repository.SaveChanges();
        
        return true;
    }
}