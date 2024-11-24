using AutoMapper;
using MediatR;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Command;

public class RemoveTicketCommand : IRequest<bool>
{
    public required Guid Id { get; set; } 
}

public class RemoveTicketCommandHandler : IRequestHandler<RemoveTicketCommand, bool>
{
    private readonly ITicketRepository _repository;
    private readonly IMapper _mapper;

    public RemoveTicketCommandHandler(ITicketRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(RemoveTicketCommand request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetByIdAsync(request.Id);
        
        if (model == null) return false;

        await _repository.RemoveAsync(model);
        
        _repository.SaveChanges();
            
        return true;
    }
}