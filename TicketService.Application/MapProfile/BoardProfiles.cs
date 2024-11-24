using AutoMapper;
using TicketService.Application.Dto;
using TicketService.Domain;

namespace TicketService.Application.MapProfile;

public class BoardProfile : Profile
{
    public BoardProfile()
    {
        CreateMap<Board, GetBoardDto>();
        CreateMap<CreateBoardDto, Board>();
    }
}
