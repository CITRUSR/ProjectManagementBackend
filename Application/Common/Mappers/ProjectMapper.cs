using Application.Project;

namespace Application.Common.Mappers;

public class ProjectMapper : IMapper<Domain.Project, ProjectViewModel>
{
    public ProjectViewModel Map(Domain.Project fromObject)
    {
        return new ProjectViewModel
        {
            Id = fromObject.Id,
            OwnerId = fromObject.OwnerId,
            Title = fromObject.Title,
            Status = fromObject.Status,
            DateStart = fromObject.DateStart,
            DateEnd = fromObject.DateEnd,
        };
    }
}