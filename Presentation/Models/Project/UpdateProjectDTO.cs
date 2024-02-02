using Domain.Enum;

namespace Presentation.Models.Project;

public record UpdateProjectDTO(
    Guid ProjectId,
    DateTime DateStart,
    DateTime DateEnd,
    ProjectStatus Status,
    Guid OwnerId,
    string Title);