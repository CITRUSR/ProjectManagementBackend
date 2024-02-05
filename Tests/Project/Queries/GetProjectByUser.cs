using System.Security.Claims;
using Application.Common.Exceptions;
using Application.Project.Queries.GetProjectByUser;
using AutoFixture;
using Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace Tests.Project.Queries;

public class GetProjectByUser : Context
{
    [Fact]
    private async System.Threading.Tasks.Task GetProjectByUser_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var userStoreMock = new Mock<IUserStore<AppUser>>();
        var userManagerMock =
            new Mock<UserManager<AppUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

        var appUser = fixture.Create<AppUser>();

        var project = fixture.Build<Domain.Project>().With(x => x.Id, appUser.ProjectId).Create();
        await DbContext.AddAsync(project);
        await DbContext.SaveChangesAsync();

        userManagerMock.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(appUser);

        HttpContext httpContext = new DefaultHttpContext();

        httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, appUser.UserName),
        }, "Mock"));

        var accessor = new HttpContextAccessor();
        accessor.HttpContext = httpContext;

        var handler = new GetProjectByUserQueryHandler(DbContext, userManagerMock.Object, accessor);

        var result = await handler.Handle(new GetProjectByUserQuery(), CancellationToken.None);

        DbContext.Projects.FirstOrDefault(x => x.Id == appUser.ProjectId).Should().BeEquivalentTo(result);
    }

    [Fact]
    private async System.Threading.Tasks.Task GetProjectByUser_ShouldBe_IdentityException()
    {
        var userStore = new Mock<IUserStore<AppUser>>();
        var userManager =
            new Mock<UserManager<AppUser>>(userStore.Object, null, null, null, null, null, null, null, null);

        var httpContext = new DefaultHttpContext();

        var accessor = new HttpContextAccessor();
        accessor.HttpContext = httpContext;

        var handler = new GetProjectByUserQueryHandler(DbContext, userManager.Object, accessor);

        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(new GetProjectByUserQuery(), CancellationToken.None);

        await act.Should().ThrowAsync<IdentityException>();
    }

    [Fact]
    private async System.Threading.Tasks.Task GetProjectByUser_ShouldBe_NotFoundException()
    {
        var fixture = new Fixture();

        var userStore = new Mock<IUserStore<AppUser>>();
        var userManager =
            new Mock<UserManager<AppUser>>(userStore.Object, null, null, null, null, null, null, null, null);

        var appUser = fixture.Create<AppUser>();

        userManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(appUser);

        var httpContext = new DefaultHttpContext();
        httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, appUser.UserName)
        }, "Mock"));
        var accessor = new HttpContextAccessor();
        accessor.HttpContext = httpContext;

        var handler = new GetProjectByUserQueryHandler(DbContext, userManager.Object, accessor);

        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(new GetProjectByUserQuery(), CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }
}