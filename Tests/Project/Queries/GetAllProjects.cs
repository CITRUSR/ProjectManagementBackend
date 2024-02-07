using Application.Common.Mappers;
using Application.Project.Queries.GetAllProjects;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Tests.Project.Queries;

public class GetAllProjects : Context
{
    [Fact]
    private async System.Threading.Tasks.Task GetAllProjects_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var projectsExpected = fixture.CreateMany<Domain.Project>(5).ToList();
        await DbContext.AddRangeAsync(projectsExpected);
        await DbContext.SaveChangesAsync();

        var handler = new GetAllProjectsQueryHandler(DbContext, new ProjectMapper());

        var projectsResult = await handler.Handle(new GetAllProjectsQuery(), CancellationToken.None);

        projectsResult.Should().HaveCount(DbContext.Projects.Count());
    }
}