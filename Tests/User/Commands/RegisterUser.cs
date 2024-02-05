using Application.Auth.User.Commands.RegisterUser;
using Application.Common.Exceptions;
using AutoFixture;
using Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace Tests.User.Commands;

public class RegisterUser : Context
{
    [Fact]
    private async System.Threading.Tasks.Task RegisterUser_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var userStore = new Mock<IUserStore<AppUser>>();
        var userManager =
            new Mock<UserManager<AppUser>>(userStore.Object, null, null, null, null, null, null, null, null);

        userManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);

        var handler = new RegisterUserCommandHandler(userManager.Object);
        var command = fixture.Create<RegisterUserCommand>();

        await handler.Handle(command, CancellationToken.None);

        userManager.Verify(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()), Times.Once);
    }

    [Fact]
    private async System.Threading.Tasks.Task RegisterUser_ShouldBe_IdentityException()
    {
        var fixture = new Fixture();
        
        var userStore = new Mock<IUserStore<AppUser>>();
        var userManager =
            new Mock<UserManager<AppUser>>(userStore.Object, null, null, null, null, null, null, null, null);

        userManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed());

        var command = fixture.Create<RegisterUserCommand>();
        var handler = new RegisterUserCommandHandler(userManager.Object);

        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(command, CancellationToken.None);
        await act.Should().ThrowAsync<IdentityException>();
    }
}