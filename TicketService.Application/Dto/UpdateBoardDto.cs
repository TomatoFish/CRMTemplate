namespace TicketService.Application.Dto;

public class UpdateBoardDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Title { get; set; }
}