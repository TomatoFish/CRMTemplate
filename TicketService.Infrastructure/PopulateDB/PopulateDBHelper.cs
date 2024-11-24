namespace TicketService.Infrastructure.PopulateDB;

public class PopulateDBHelper
{
    public static void PopulateDB(this IApplicationBuilder app, bool isProduction)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetService<TicketServiceDbContext>();
            if (dbContext != null)
            {
                if (isProduction)
                    SeedDataProd(dbContext);
                else
                    SeedDataDev(dbContext);
            }
        }
    }

    private static void SeedDataDev(TicketServiceDbContext dbContext)
    {
        
    }

    private static void SeedDataProd(TicketServiceDbContext dbContext)
    {
        Console.WriteLine("--> Applying migrations...");
        try
        {
            dbContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Can't run migrations: {ex.Message}");
        }
    }
}