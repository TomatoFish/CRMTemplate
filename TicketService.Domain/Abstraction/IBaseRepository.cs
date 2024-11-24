namespace TicketService.Domain.Abstraction;

public interface IBaseRepository<T>
{
    void SaveChanges();
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(T item);
    Task UpdateAsync(T item);
    Task RemoveAsync(T item);
}