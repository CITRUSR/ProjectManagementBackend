using System.Security.Claims;
using Application.Common.Exceptions;
using Application.Common.Mappers;
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

        var userId = Guid.NewGuid();

        var project = fixture.Build<Domain.Project>().With(x => x.OwnerId, userId).Create();
        await DbContext.AddAsync(project);
        await DbContext.SaveChangesAsync();

        var handler = new GetProjectByUserQueryHandler(DbContext, new ProjectMapper());

        var result = await handler.Handle(new GetProjectByUserQuery(userId), CancellationToken.None);

        DbContext.Projects.FirstOrDefault(x => x.OwnerId == userId).Should().BeEquivalentTo(result);
    }

    [Fact]
    private async System.Threading.Tasks.Task GetProjectByUser_ShouldBe_NotFoundException()
    {
        var fixture = new Fixture();

        var handler = new GetProjectByUserQueryHandler(DbContext, new ProjectMapper());

        Func<System.Threading.Tasks.Task> act = async () =>
            await handler.Handle(new GetProjectByUserQuery(Guid.NewGuid()), CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }
}