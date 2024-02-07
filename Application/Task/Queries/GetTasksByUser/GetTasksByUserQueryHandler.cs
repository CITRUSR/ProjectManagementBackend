using Application.Common.Mappers;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries.GetTasksByUser;

public class GetTasksByUserQueryHandler(
    IAppDbContext dbContext,
    TaskMapper mapper)
    : IRequestHandler<GetTasksByUserQuery, List<TaskViewModel>>
{
    private readonly IAppDbContext _dbContext = dbContext;
    private readonly TaskMapper _mapper = mapper;

    public async Task<List<TaskViewModel>> Handle(GetTasksByUserQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Tasks.Where(x => x.OwnerId == request.OwnerId).Select(x => _mapper.Map(x))
            .ToList();
    }
}