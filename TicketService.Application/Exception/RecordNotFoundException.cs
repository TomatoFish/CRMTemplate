namespace TicketService.Application.Exception;

public class RecordNotFoundException : System.Exception
{
    private readonly System.Exception[] _innerExceptions;
    
    public RecordNotFoundException(string? message) : base(message)
    {
        _innerExceptions = Array.Empty<System.Exception>();
    }
}