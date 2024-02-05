using System.ComponentModel.DataAnnotations;
using Domain.Enum;
using Newtonsoft.Json;

namespace Presentation.Models.Task;

public record CreateTaskDTO(
    Guid ProjectId,
    Guid OwnerId,
    string Title,
    WorkStatus Status,
    Priority Priority,
    DateTime DateStart,
    DateTime DateEnd
);