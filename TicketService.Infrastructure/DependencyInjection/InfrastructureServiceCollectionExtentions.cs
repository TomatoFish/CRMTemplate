using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketService.Domain.Abstraction;
using TicketService.Infrastructure.Context;
using TicketService.Infrastructure.Repository;

namespace TicketService.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool isProduction)
    {
        if (isProduction)
        {
            Console.WriteLine("--> Use Postgres Database");
            services.AddDbContext<TicketServiceDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DbContext"));
            });
        }
        else
        {
            Console.WriteLine("--> Use InMemory Database");
            services.AddDbContext<TicketServiceDbContext>(options => 
            {
                options.UseInMemoryDatabase("InMemory");
            });
        }
        
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IBoardRepository, BoardRepository>();

        return services;
    }
}