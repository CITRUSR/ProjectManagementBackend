using Application.Common.Exceptions;
using Application.Common.Mappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries.GetTaskById;

public class GetTaskByIdQueryHandler(IAppDbContext dbContext, TaskMapper mapper)
    : IRequestHandler<GetTaskByIdQuery, TaskViewModel>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly TaskMapper _mapper = mapper;

    public async Task<TaskViewModel> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new NotFoundException($"Task with id:{request.Id} is not found");
        }

        return _mapper.Map(task);
    }
}