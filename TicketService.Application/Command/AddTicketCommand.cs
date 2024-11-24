using AutoMapper;
using MediatR;
using TicketService.Application.Dto;
using TicketService.Domain;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Command;

public class AddTicketCommand : IRequest<Guid>
{
    public required CreateTicketDto Dto { get; set; }
}

public class AddTicketCommandHandler : IRequestHandler<AddTicketCommand, Guid>
{
    private readonly ITicketRepository _repository;
    private readonly IMapper _mapper;

    public AddTicketCommandHandler(ITicketRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(AddTicketCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Ticket>(request.Dto);
        
        model.Id = Guid.NewGuid();
        model.CreateDateTime = DateTime.UtcNow;
        model.UpdateDateTime = DateTime.UtcNow;
        
        var resultId = await _repository.AddAsync(model);

        _repository.SaveChanges();
            
        return resultId;
    }
}