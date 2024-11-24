using TicketService.Domain;
using TicketService.Domain.Abstraction;
using TicketService.Infrastructure.Context;

namespace TicketService.Infrastructure.Repository;

internal class TicketRepository : ITicketRepository
{
    private readonly TicketServiceDbContext _dbContext;
    
    public TicketRepository(TicketServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
    
    public Task<List<Ticket>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.Tickets.ToList());
    }

    public Task<Ticket?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_dbContext.Tickets.FirstOrDefault(i => i.Id == id));
    }

    public Task<Guid> AddAsync(Ticket item)
    {
        _dbContext.Tickets.Add(item);

        return Task.FromResult(item.Id);
    }
    
    public Task UpdateAsync(Ticket item)
    {
        _dbContext.Tickets.Update(item);
        
        return Task.CompletedTask;
    }
    
    public Task RemoveAsync(Ticket item)
    {
        _dbContext.Tickets.Remove(item);
        
        return Task.CompletedTask;
    }
}