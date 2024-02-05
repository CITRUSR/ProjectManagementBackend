using Infrastructure;
using MediatR;

namespace Application.Task.Commands.CreateTask;

public class CreateTaskCommandHandler(IAppDbContext dbContext) : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new Domain.Task
        {
            Id = Guid.NewGuid(),
            ProjectId = request.ProjectId,
            OwnerId = request.OwnerId,
            Title = request.Title,
            DateStart = request.DateStart,
            DateEnd = request.DateEnd,
            Status = request.Status,
            Priority = request.Priority,
        };

        await _dbContext.Tasks.AddAsync(task, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}