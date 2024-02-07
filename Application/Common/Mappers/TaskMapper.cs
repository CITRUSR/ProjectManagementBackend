using Application.Task;

namespace Application.Common.Mappers;

public class TaskMapper : IMapper<Domain.Task, TaskViewModel>
{
    public TaskViewModel Map(Domain.Task fromObject)
    {
        return new TaskViewModel
        {
            Id = fromObject.Id,
            OwnerId = fromObject.OwnerId,
            ProjectId = fromObject.ProjectId,
            Title = fromObject.Title,
            Status = fromObject.Status,
            Priority = fromObject.Priority,
            DateStart = fromObject.DateStart,
            DateEnd = fromObject.DateEnd,
        };
    }
}