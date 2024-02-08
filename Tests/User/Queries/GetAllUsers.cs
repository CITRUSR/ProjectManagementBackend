using Application.Auth.User.Queries.GetAllUsers;
using Application.Common.Mappers;
using AutoFixture;
using Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Tests.User.Queries;

public class GetAllUsers : Context
{
    [Fact]
    private async System.Threading.Tasks.Task GetAllUsers_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var userManager = new Mock<UserManager<AppUser>>(
            new Mock<IUserStore<AppUser>>().Object, null, null, null, null, null, null, null, null);
        var users = fixture.CreateMany<AppUser>(10).ToList();

        userManager.Setup(u => u.Users)
            .Returns(users.AsQueryable());

        foreach (var user in users)
        {
            await userManager.Object.CreateAsync(user, "Qwerty12345GHJ");
        }

        var handler = new GetAllUsersQueryHandler(userManager.Object, new UserMapper());

        var usersResult = await handler.Handle(new GetAllUsersQuery(), CancellationToken.None);

        usersResult.Should().HaveCount(userManager.Object.Users.ToList().Count);
    }
}