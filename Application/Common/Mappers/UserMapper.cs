using Application.Auth.User;
using Domain;

namespace Application.Common.Mappers;

public class UserMapper : IMapper<AppUser, UserViewModel>
{
    public UserViewModel Map(AppUser fromObject)
    {
        return new UserViewModel
        {
            Id = fromObject.Id,
            Name = fromObject.UserName,
            Position = fromObject.Position,
            IsConfirmedProfile = fromObject.IsConfirmedProfile,
        };
    }
}