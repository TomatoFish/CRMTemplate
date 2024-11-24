namespace TicketService.Application.Dto;

public class CreateTicketDto
{
    public string Name { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public Guid BoardId { get; set; }
}