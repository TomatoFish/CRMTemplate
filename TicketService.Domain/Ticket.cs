namespace TicketService.Domain;

public class Ticket
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    
    public DateTime UpdateDateTime { get; set; }
    
    public Guid BoardId { get; set; }
    
    public Board Board { get; set; }
}