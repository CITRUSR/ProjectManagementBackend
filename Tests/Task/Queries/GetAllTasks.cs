using Application.Task.Queries.GetAllTasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.Task.Queries;

public class GetAllTasks : Context
{
    [Fact]
    private async System.Threading.Tasks.Task GetAllTask_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var tasks = fixture.CreateMany<Domain.Task>(5);
        await DbContext.AddRangeAsync(tasks);
        await DbContext.SaveChangesAsync();

        var handler = new GetAllTasksQueryHandler(DbContext);

        var getTasks = await handler.Handle(new GetAllTasksQuery(), CancellationToken.None);
        getTasks.Should().HaveCount(DbContext.Tasks.Count());
    }
}