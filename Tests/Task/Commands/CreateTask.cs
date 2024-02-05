using Application.Task.Commands.CreateTask;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Tests.Task.Commands;

public class CreateTask : Context
{
    [Fact]
    private async System.Threading.Tasks.Task CreateTask_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var command = fixture.Create<CreateTaskCommand>();
        var handler = new CreateTaskCommandHandler(DbContext);

        var createdTaskId = await handler.Handle(command, CancellationToken.None);

        DbContext.Tasks.FirstOrDefault(x => x.Id == createdTaskId).Should().NotBeNull();
    }
}