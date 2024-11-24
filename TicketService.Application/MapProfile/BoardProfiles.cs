using AutoMapper;
using TicketService.Application.Dto;
using TicketService.Domain;

namespace TicketService.Application.MapProfile;

public class BoardProfiles : Profile
{
    public BoardProfiles()
    {
        CreateMap<Board, GetBoardDto>();
        CreateMap<CreateBoardDto, Board>();
    }
}
