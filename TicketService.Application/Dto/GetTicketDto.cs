namespace TicketService.Application.Dto;

public class GetTicketDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    
    public DateTime UpdateDateTime { get; set; }
}