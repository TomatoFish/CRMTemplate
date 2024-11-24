using Microsoft.Extensions.DependencyInjection;

namespace TicketService.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtentions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddScoped<>();

        return services;
    }
}