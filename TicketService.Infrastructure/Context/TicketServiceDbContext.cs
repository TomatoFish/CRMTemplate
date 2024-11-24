using Microsoft.EntityFrameworkCore;
using TicketService.Domain;

namespace TicketService.Infrastructure.Context;

internal class TicketServiceDbContext : DbContext
{
    public TicketServiceDbContext(DbContextOptions<TicketServiceDbContext> options) : base(options)
    {
    }
    
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Board> Boards { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Board>().HasMany(e => e.Tickets).WithOne(e => e.Board).HasForeignKey(e => e.BoardId);
    }
}