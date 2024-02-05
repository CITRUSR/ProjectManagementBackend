using Application.Common.Exceptions;
using Application.Task.Commands.DeleteTask;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Tests.Task.Commands;

public class DeleteTask : Context
{
    [Fact]
    private async System.Threading.Tasks.Task DeleteTask_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var task = fixture.Create<Domain.Task>();
        await DbContext.AddAsync(task);
        await DbContext.SaveChangesAsync();

        var command = new DeleteTaskCommand(task.Id);
        var handler = new DeleteTaskCommandHandler(DbContext);

        await handler.Handle(command, CancellationToken.None);
        DbContext.Tasks.FirstOrDefault(x => x.Id == task.Id).Should().BeNull();
    }

    [Fact]
    private async System.Threading.Tasks.Task DeleteTask_ShouldBe_NotFoundException()
    {
        var fixture = new Fixture();

        var command = fixture.Create<DeleteTaskCommand>();
        var handler = new DeleteTaskCommandHandler(DbContext);

        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(command, CancellationToken.None);
        await act.Should().ThrowAsync<NotFoundException>();
    }
}