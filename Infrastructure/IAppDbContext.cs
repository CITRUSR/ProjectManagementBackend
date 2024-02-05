using Domain;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Task;

namespace Infrastructure;

public interface IAppDbContext
{ 
    DbSet<Project> Projects { get; set; }
    DbSet<Task> Tasks { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}