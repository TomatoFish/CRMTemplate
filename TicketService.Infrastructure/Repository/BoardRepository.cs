using Microsoft.EntityFrameworkCore;
using TicketService.Domain;
using TicketService.Domain.Abstraction;
using TicketService.Infrastructure.Context;

namespace TicketService.Infrastructure.Repository;

internal class BoardRepository : IBoardRepository
{
    private readonly TicketServiceDbContext _dbContext;

    public BoardRepository(TicketServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
    
    public Task<List<Board>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.Boards.ToList());
    }

    public Task<Board?> GetByIdAsync(Guid id)
    {
        var queryable = _dbContext.Boards.Include(b => b.Tickets);
        return Task.FromResult(queryable.FirstOrDefault(i => i.Id == id));
    }

    public Task<Guid> AddAsync(Board item)
    {
        _dbContext.Boards.Add(item);
        
        return Task.FromResult(item.Id);
    }

    public Task UpdateAsync(Board item)
    {
        _dbContext.Boards.Update(item);
        
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Board item)
    {
        _dbContext.Boards.Remove(item);
        
        return Task.CompletedTask;
    }
}