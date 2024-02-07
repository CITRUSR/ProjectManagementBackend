using Domain.Enum;

namespace Application.Auth.User;

public class UserViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Position Position { get; set; }
    public bool IsConfirmedProfile { get; set; }
}