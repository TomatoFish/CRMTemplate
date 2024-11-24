using AutoMapper;
using MediatR;
using TicketService.Application.Dto;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Query;

public class GetAllBoardsQuery : IRequest<List<GetBoardDto>>
{
}

public class GetAllBoardsQueryHandler : IRequestHandler<GetAllBoardsQuery, List<GetBoardDto>>
{
    private readonly IBoardRepository _repository;
    private readonly IMapper _mapper;

    public GetAllBoardsQueryHandler(IBoardRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetBoardDto>> Handle(GetAllBoardsQuery request, CancellationToken cancellationToken)
    {
        var models = await _repository.GetAllAsync();

        var dtos = _mapper.Map<List<GetBoardDto>>(models);
        
        return dtos;
    }
}