using Application.Common.Exceptions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Commands.DeleteTask;

public class DeleteTaskCommandHandler(IAppDbContext dbContext) : IRequestHandler<DeleteTaskCommand>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public async System.Threading.Tasks.Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new NotFoundException($"The task with id:{request.Id} is not Found");
        }

        _dbContext.Tasks.Remove(task);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}