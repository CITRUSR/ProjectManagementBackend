using Infrastructure;

namespace Tests;

public class Context : IDisposable
{
    protected AppDbContext DbContext;

    public Context()
    {
        DbContext = AppDbContextFactory.Create();
    }

    public void Dispose()
    {
        AppDbContextFactory.Destroy(DbContext);
    }
}