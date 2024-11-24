using AutoMapper;
using TicketService.Application.Dto;
using TicketService.Domain;

namespace TicketService.Application.MapProfile;

public class TicketProfiles : Profile
{
    public TicketProfiles()
    {
        CreateMap<Ticket, GetTicketDto>();
        CreateMap<CreateTicketDto, Ticket>();
    }
}
