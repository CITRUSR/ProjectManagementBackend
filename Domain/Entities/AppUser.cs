using Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Domain;

public class AppUser : IdentityUser
{
    public Guid ProjectId { get; set; }
    public bool IsConfirmedProfile { get; set; }
    public Position Position { get; set; }
}