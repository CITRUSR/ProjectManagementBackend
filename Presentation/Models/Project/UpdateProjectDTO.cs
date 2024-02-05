using System.ComponentModel.DataAnnotations;
using Domain.Enum;
using Newtonsoft.Json;

namespace Presentation.Models.Project;

public record UpdateProjectDTO(
    Guid ProjectId,
    DateTime DateStart,
    DateTime DateEnd,
    WorkStatus Status,
    Guid OwnerId,
    string Title);