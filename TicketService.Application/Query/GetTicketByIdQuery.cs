using AutoMapper;
using MediatR;
using TicketService.Application.Dto;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Query;

public class GetTicketByIdQuery : IRequest<GetTicketDto?>
{
    public required Guid Id { get; set; }
}

public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, GetTicketDto?>
{
    private readonly ITicketRepository _repository;
    private readonly IMapper _mapper;

    public GetTicketByIdQueryHandler(ITicketRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetTicketDto?> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetByIdAsync(request.Id);

        if (model == null) return null;
        
        var dto = _mapper.Map<GetTicketDto>(model);

        return dto;
    }
}