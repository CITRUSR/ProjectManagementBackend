using Domain.Enum;

namespace Domain;

public class Project
{
    public string Title { get; set; }
    public Guid OwnerId { get; set; }
    public ProjectStatus Status { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}
