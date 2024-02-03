using Application.Project.Commands;
using AutoFixture;
using FluentAssertions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Tests.Project;

public class CreateProject : Context
{
    [Fact]
    private async Task CreateProject_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var projectExpect = fixture.Create<Domain.Project>();

        await DbContext.AddAsync(projectExpect);
        await DbContext.SaveChangesAsync();

        var handler = new CreateProjectCommandHandler(DbContext);

        var command = fixture.Create<CreateProjectCommand>();
        var project = await handler.Handle(command, CancellationToken.None);

        DbContext.Projects.FirstOrDefault(x => x.Id == project).Should().NotBeNull();
    }
}