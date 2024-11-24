namespace TicketService.Domain;

public class Board
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Title { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    
    public DateTime UpdateDateTime { get; set; }
    
    public IEnumerable<Ticket> Tickets { get; set; }
}