using AutoMapper;
using MediatR;
using TicketService.Application.Dto;
using TicketService.Domain;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Query;

public class GetBoardByIdQuery : IRequest<GetBoardDto?>
{
    public required Guid Id { get; set; }
}

public class GetBoardByIdQueryHandler : IRequestHandler<GetBoardByIdQuery, GetBoardDto?>
{
    private readonly IBoardRepository _repository;
    private readonly IMapper _mapper;

    public GetBoardByIdQueryHandler(IBoardRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetBoardDto?> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetByIdAsync(request.Id);

        if (model == null) return null;
        
        var dto = _mapper.Map<GetBoardDto>(model);

        return dto;
    }
}