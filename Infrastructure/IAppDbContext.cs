using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public interface IAppDbContext
{ 
    DbSet<Project> Projects { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}