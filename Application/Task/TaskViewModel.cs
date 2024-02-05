using System.ComponentModel.DataAnnotations;
using Domain.Enum;
using Newtonsoft.Json;

namespace Application.Task;

public class TaskViewModel
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid OwnerId { get; set; }
    public string Title { get; set; }
    public WorkStatus Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}