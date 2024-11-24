using AutoMapper;
using MediatR;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Command;

public class RemoveBoardCommand : IRequest<bool>
{
    public required Guid Id { get; set; } 
}

public class RemoveBoardCommandHandler : IRequestHandler<RemoveBoardCommand, bool>
{
    private readonly IBoardRepository _repository;
    private readonly IMapper _mapper;

    public RemoveBoardCommandHandler(IBoardRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(RemoveBoardCommand request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetByIdAsync(request.Id);
        
        if (model == null) return false;

        await _repository.RemoveAsync(model);
        
        _repository.SaveChanges();
            
        return true;
    }
}