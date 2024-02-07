using Application.Common.Exceptions;
using Application.Common.Mappers;
using Application.Project.Queries.GetProjectById;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Tests.Project.Queries;

public class GetProjectById : Context
{
    [Fact]
    private async System.Threading.Tasks.Task GetProjectById_ShouldBe_Success()
    {
        var fixture = new Fixture();

        var project = fixture.Create<Domain.Project>();
        await DbContext.AddAsync(project);
        await DbContext.SaveChangesAsync();

        var handler = new GetProjectByIdQueryHandler(DbContext, new ProjectMapper());

        var projectResult = await handler.Handle(new GetProjectByIdQuery(project.Id), CancellationToken.None);
        
        projectResult.Should().BeEquivalentTo(project);
    }

    [Fact]
    private async System.Threading.Tasks.Task GetProjectById_ShouldBe_NotFoundException()
    {
        var fixture = new Fixture();

        var project = fixture.Create<Domain.Project>();

        var handler = new GetProjectByIdQueryHandler(DbContext, new ProjectMapper());

        Func<System.Threading.Tasks.Task> act = async () => await handler.Handle(new GetProjectByIdQuery(project.Id), CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }
}