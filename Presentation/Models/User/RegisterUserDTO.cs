using Domain.Enum;

namespace Presentation.Models.User;

public record RegisterUserDTO(string Login, Position Position, string Password, string ConfirmPassword);