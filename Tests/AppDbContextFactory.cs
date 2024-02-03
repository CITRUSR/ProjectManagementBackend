using Domain.Enum;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class AppDbContextFactory
{
    public static AppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        AppDbContext dbContext = new AppDbContext(options);

        dbContext.Database.EnsureCreated();

        dbContext.SaveChanges();

        return dbContext;
    }

    public static void Destroy(AppDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}