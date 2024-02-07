using Application.Common.Exceptions;
using Application.Common.Mappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Commands.UpdateTask;

public class UpdateTaskCommandHandler(IAppDbContext dbContext, TaskMapper mapper) : IRequestHandler<UpdateTaskCommand, TaskViewModel>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly TaskMapper _mapper = mapper;

    public async Task<TaskViewModel> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new NotFoundException($"The task with id:{request.Id} is not found");
        }

        task.Title = request.Title;
        task.Status = request.Status;
        task.Priority = request.Priority;
        task.DateStart = request.DateStart;
        task.DateEnd = request.DateEnd;
        task.OwnerId = request.OwnerId;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map(task);
    }
}