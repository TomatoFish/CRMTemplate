using AutoMapper;
using MediatR;
using TicketService.Application.Dto;
using TicketService.Domain;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Command;

public class AddBoardCommand : IRequest<Guid>
{
    public required CreateBoardDto Dto { get; set; }
}

public class AddBoardCommandHandler : IRequestHandler<AddBoardCommand, Guid>
{
    private readonly IBoardRepository _repository;
    private readonly IMapper _mapper;

    public AddBoardCommandHandler(IBoardRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(AddBoardCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Board>(request.Dto);

        model.Id = Guid.NewGuid();
        model.CreateDateTime = DateTime.UtcNow;
        model.UpdateDateTime = DateTime.UtcNow;
        
        var resultId = await _repository.AddAsync(model);

        _repository.SaveChanges();
            
        return resultId;
    }
}