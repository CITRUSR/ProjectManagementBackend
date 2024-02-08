using System.Security.Cryptography.Xml;
using Application.Common.Mappers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Auth.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(UserManager<AppUser> userManager, UserMapper mapper)
    : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly UserMapper _mapper = mapper;

    public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _userManager.Users.Select(x => _mapper.Map(x)).ToList();

        return users;
    }
}