using AutoMapper;
using MediatR;
using TicketService.Application.Dto;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Query;

public class GetAllTicketsQuery : IRequest<List<GetTicketDto>>
{
}

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<GetTicketDto>>
{
    private readonly ITicketRepository _repository;
    private readonly IMapper _mapper;

    public GetAllTicketsQueryHandler(ITicketRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetTicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var models = await _repository.GetAllAsync();

        var dtos = _mapper.Map<List<GetTicketDto>>(models);
        
        return dtos;
    }
}