using Application.Common.Mappers;
using Application.Task.Queries.GetTasksByUser;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Tests.Task.Queries;

public class GetTasksByUser : Context
{
    [Fact]
    private async System.Threading.Tasks.Task GetTasksByUser_ShouldBe_Success()
    {
        var fixture = new Fixture();

        Guid ownerId = Guid.NewGuid();

        var tasks = fixture.Build<Domain.Task>().With(x => x.OwnerId, ownerId).CreateMany(5);
        await DbContext.AddRangeAsync(tasks);
        await DbContext.SaveChangesAsync();

        var query = new GetTasksByUserQuery(ownerId);
        var handler = new GetTasksByUserQueryHandler(DbContext, new TaskMapper());

        var tasksResult = await handler.Handle(query, CancellationToken.None);
        tasksResult.Should().HaveCount(DbContext.Tasks.Where(x => x.OwnerId == ownerId).Count());
    }
}