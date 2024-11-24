using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TicketService.Domain;
using TicketService.Infrastructure.Context;

namespace TicketService.Infrastructure.PopulateDB;

public static class PopulateDBHelper
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
    
    private static void SeedDataDev(TicketServiceDbContext dbContext)
    {
        Console.WriteLine("--> Seed dev db...");
        SeedBoards(dbContext);
        SeedTickets(dbContext);

        dbContext.SaveChanges();
    }

    private static void SeedBoards(TicketServiceDbContext dbContext)
    {
        if (dbContext.Boards.Any()) return;

        var now = DateTime.Now;
        dbContext.Boards.AddRange(new []
        {
            new Board
            {
                Id = new Guid("ce731db5-47d2-49cc-86a6-11e6aa668844"),
                Name = "B1",
                Title = "TestBoard_1",
                CreateDateTime = now,
                UpdateDateTime = now,
            },
            new Board
            {
                Id = new Guid("02e69c65-1715-473c-a5b0-281098005bbd"),
                Name = "B2",
                Title = "TestBoard_2",
                CreateDateTime = now,
                UpdateDateTime = now,
            },
        });
    }
    
    private static void SeedTickets(TicketServiceDbContext dbContext)
    {
        if (dbContext.Tickets.Any()) return;
        
        var now = DateTime.Now;
        dbContext.Tickets.AddRange(new []
        {
            new Ticket
            {
                Id = new Guid("464ac20d-7f0d-4c60-95ee-4ce8dd60678a"),
                CreateDateTime = now,
                UpdateDateTime = now,
                Name = "B1T1",
                Title = "Board 1. Test Ticket 1",
                Description = "Test ticket description",
                BoardId = new Guid("ce731db5-47d2-49cc-86a6-11e6aa668844"),
            },
            new Ticket
            {
                Id = new Guid("3dfc803a-2e49-402c-9b60-c0d06d968167"),
                CreateDateTime = now,
                UpdateDateTime = now,
                Name = "B1T2",
                Title = "Board 1. Test Ticket 2",
                Description = "Test ticket description",
                BoardId = new Guid("ce731db5-47d2-49cc-86a6-11e6aa668844"),
            },
            new Ticket
            {
                Id = new Guid("9099d9ab-9191-4ef6-8c9b-8091ad64fb23"),
                CreateDateTime = now,
                UpdateDateTime = now,
                Name = "B1T3",
                Title = "Board 1. Test Ticket 3",
                Description = "Test ticket description",
                BoardId = new Guid("ce731db5-47d2-49cc-86a6-11e6aa668844"),
            },
            new Ticket
            {
                Id = new Guid("2c617488-f947-4316-b77a-3f3b7ee7d6ad"),
                CreateDateTime = now,
                UpdateDateTime = now,
                Name = "B2T1",
                Title = "Board 2. Test Ticket 1",
                Description = "Test ticket description",
                BoardId = new Guid("02e69c65-1715-473c-a5b0-281098005bbd"),
            },
            new Ticket
            {
                Id = new Guid("4f5741c5-0f5a-44f1-86ba-54d61ef726a4"),
                CreateDateTime = now,
                UpdateDateTime = now,
                Name = "B2T2",
                Title = "Board 2. Test Ticket 2",
                Description = "Test ticket description",
                BoardId = new Guid("02e69c65-1715-473c-a5b0-281098005bbd"),
            },
        });
    }
}