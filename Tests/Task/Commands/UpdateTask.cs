using Application.Common.Exceptions;
using Application.Task.Commands.UpdateTask;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Tests.Task.Commands;

public class UpdateTask : Context
{
    [Fact]
    private async System.Threading.Tasks.Task UpdateTask_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var task = fixture.Create<Domain.Task>();
        await DbContext.AddAsync(task);
        await DbContext.SaveChangesAsync();

        var command = fixture.Build<UpdateTaskCommand>().With(x => x.Id, task.Id).Create();
        var handler = new UpdateTaskCommandHandler(DbContext);
        var newTask = await handler.Handle(command, CancellationToken.None);

        DbContext.Tasks.FirstOrDefault(x => x.Id == task.Id).Should().BeEquivalentTo(newTask);
    }

    [Fact]
    private async System.Threading.Tasks.Task UpdateTask_ShouldBe_NotFoundException()
    {
        var fixture = new Fixture();

        var command = fixture.Create<UpdateTaskCommand>();
        var handler = new UpdateTaskCommandHandler(DbContext);

        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }
}