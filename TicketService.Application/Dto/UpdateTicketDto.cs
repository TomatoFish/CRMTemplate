namespace TicketService.Application.Dto;

public class UpdateTicketDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
}