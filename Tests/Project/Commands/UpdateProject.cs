using Application.Common.Exceptions;
using Application.Project.Commands.UpdateProject;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Tests.Project;

public class UpdateProject : Context
{
    [Fact]
    private async System.Threading.Tasks.Task UpdateProject_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var oldProject = fixture.Create<Domain.Project>();
        await DbContext.Projects.AddAsync(oldProject);
        await DbContext.SaveChangesAsync();

        var commandHandler = new UpdateProjectCommandHandler(DbContext);

        var command = fixture.Build<UpdateProjectCommand>().With(x => x.ProjectId, oldProject.Id).Create();

        var updatedProject = await commandHandler.Handle(command, CancellationToken.None);
        DbContext.Projects.FirstOrDefault(x => x.Id == oldProject.Id).Should().BeEquivalentTo(updatedProject);
    }

    [Fact]
    private async System.Threading.Tasks.Task UpdateProject_ShouldBe_NotFoundException()
    {
        var fixture = new Fixture();
        var commandHandler = new UpdateProjectCommandHandler(DbContext);

        var command = fixture.Create<UpdateProjectCommand>();
        
        Func<System.Threading.Tasks.Task> act = async () => await commandHandler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }
}