using Application.Task.Queries.GetTasksByProject;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Tests.Task.Queries;

public class GetTasksByProject : Context
{
    [Fact]
    private async System.Threading.Tasks.Task GetTasksByProject_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var projectId = Guid.NewGuid();

        var tasks = fixture.Build<Domain.Task>().With(x => x.ProjectId, projectId).CreateMany(5);
        await DbContext.AddRangeAsync(tasks);
        await DbContext.SaveChangesAsync();

        var query = new GetTasksByProjectQuery(projectId);
        var handler = new GetTasksByProjectQueryHandler(DbContext);

        var tasksResult = await handler.Handle(query, CancellationToken.None);
        tasksResult.Should().HaveCount(DbContext.Tasks.Where(x => x.ProjectId == projectId).Count());
    }
}