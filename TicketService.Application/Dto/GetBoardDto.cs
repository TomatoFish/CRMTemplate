namespace TicketService.Application.Dto;

public class GetBoardDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Title { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    
    public DateTime UpdateDateTime { get; set; }
}