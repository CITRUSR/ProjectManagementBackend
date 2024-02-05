using System.Linq.Expressions;
using Application.Common.Exceptions;
using Application.Project.Commands.DeleteProject;
using AutoFixture;
using FluentAssertions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Tests.Project;

public class DeleteProject : Context
{
    [Fact]
    private async System.Threading.Tasks.Task DeleteProject_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var project = fixture.Create<Domain.Project>();

        await DbContext.AddAsync(project);
        await DbContext.SaveChangesAsync();

        var handler = new DeleteProjectCommandHandler(DbContext);
        await handler.Handle(new DeleteProjectCommand(project.Id), CancellationToken.None);

        DbContext.Projects.FirstOrDefault(x => x.Id == project.Id).Should().BeNull();
    }

    [Fact]
    private async System.Threading.Tasks.Task DeleteProject_ShouldBe_NotFoundException()
    {
        var fixture = new Fixture();

        var project = fixture.Create<Domain.Project>();

        var handler = new DeleteProjectCommandHandler(DbContext);
        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(new DeleteProjectCommand(project.Id), CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }
}