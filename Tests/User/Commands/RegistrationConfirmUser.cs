using Application.Auth;
using Application.Auth.User.Commands.RegisterConfirmUser;
using Application.Auth.User.Commands.RegisterUser;
using Application.Common.Exceptions;
using AutoFixture;
using Domain;
using Domain.Enum;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace Tests.User.Commands;

public class RegistrationConfirmUser : Context
{
    [Fact]
    private async System.Threading.Tasks.Task RegistrationConfirmUser_ShouldBe_Success()
    {
        var fixture = new Fixture();
        var user = fixture.Build<AppUser>().With(x => x.IsConfirmedProfile, false).Create();
        var userStore = new Mock<IUserStore<AppUser>>();
        var userManager =
            new Mock<UserManager<AppUser>>(userStore.Object, null, null, null, null, null, null, null, null);

        userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
        userManager.Setup(x => x.AddToRoleAsync(user, It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

        var command = new RegisterConfirmUserCommand("22", Position.It);
        var handler = new RegisterConfirmUserCommandHandler(userManager.Object);

        await handler.Handle(command, CancellationToken.None);

        userManager.Verify(x => x.AddToRoleAsync(user, It.IsAny<string>()), Times.Once);
        user.IsConfirmedProfile.Should().BeTrue();
    }

    [Fact]
    private async System.Threading.Tasks.Task RegistrationConfirmUser_ShouldBe_NotFoundException()
    {
        var fixture = new Fixture();

        var userStore = new Mock<IUserStore<AppUser>>();
        var userManager =
            new Mock<UserManager<AppUser>>(userStore.Object, null, null, null, null, null, null, null, null);

        var command = fixture.Create<RegisterConfirmUserCommand>();
        var handler = new RegisterConfirmUserCommandHandler(userManager.Object);

        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    private async System.Threading.Tasks.Task RegistrationConfirmUser_ShouldBe_IdentityException()
    {
        var fixture = new Fixture();

        var user = fixture.Create<AppUser>();

        var userStore = new Mock<IUserStore<AppUser>>();
        var userManager =
            new Mock<UserManager<AppUser>>(userStore.Object, null, null, null, null, null, null, null, null);

        userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
        userManager.Setup(x => x.AddToRoleAsync(user, It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed());

        var command = new RegisterConfirmUserCommand(user.Id, user.Position);
        var handler = new RegisterConfirmUserCommandHandler(userManager.Object);
        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<IdentityException>();
    }
}