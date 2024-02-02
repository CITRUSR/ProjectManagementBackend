namespace Presentation.Models.Project;

public record CreateProjectDTO(string Title, Guid OwnerId, DateTime DateStart, DateTime DateEnd);