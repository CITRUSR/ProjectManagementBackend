using Application.Common.Exceptions;
using Application.Task.Queries.GetTaskById;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Tests.Task.Queries;

public class GetTaskById : Context
{
    [Fact]
    private async System.Threading.Tasks.Task GetTaskById_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var task = fixture.Create<Domain.Task>();
        await DbContext.AddAsync(task);
        await DbContext.SaveChangesAsync();

        var query = new GetTaskByIdQuery(task.Id);
        var handler = new GetTaskByIdQueryHandler(DbContext);

        var taskResult = await handler.Handle(query, CancellationToken.None);
        taskResult.Should().BeEquivalentTo(DbContext.Tasks.FirstOrDefault(x => x.Id == task.Id));
    }

    [Fact]
    private async System.Threading.Tasks.Task GetTaskById_ShouldBe_NotFoundException()
    {
        var fixture = new Fixture();

        var query = fixture.Create<GetTaskByIdQuery>();
        var handler = new GetTaskByIdQueryHandler(DbContext);

        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(query, CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }
}