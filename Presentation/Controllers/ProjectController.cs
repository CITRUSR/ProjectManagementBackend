using Application.Common.Exceptions;
using Application.Project;
using Application.Project.Commands;
using Application.Project.Commands.DeleteProject;
using Application.Project.Commands.UpdateProject;
using Application.Project.Queries.GetAllProjects;
using Application.Project.Queries.GetProjectById;
using Application.Project.Queries.GetProjectByUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Project;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProjectController(IMediator mediator) : BaseController(mediator)
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Get all projects (Admin)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Get/GetAllProjects
    /// 
    /// </remarks>
    /// <returns>Ok</returns>
    /// <response code="200">Ok</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(List<ProjectViewModel>), 200)]
    public async Task<IActionResult> GetAllProjects()
    {
        var query = new GetAllProjectsQuery();

        var projects = await _mediator.Send(query);

        return Ok(projects);
    }

    /// <summary>
    /// Get project by id (Admin)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Get/GetProjectById?projectId=1
    /// 
    /// </remarks>
    /// <param name="projectId"></param>
    /// <returns>Project</returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Validation errors</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    /// <response code="404">Project is not found</response>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ProjectViewModel), 200)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), 400)]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> GetProjectById(Guid projectId)
    {
        var query = new GetProjectByIdQuery(projectId);

        var project = await _mediator.Send(query);

        return Ok(project);
    }

    /// <summary>
    /// Get project by user
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Get/GetProjectByUser
    /// 
    /// </remarks>
    /// <returns>Project</returns>
    /// <response code="200">Ok</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="404">Project is not found</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(ProjectViewModel), 200)]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> GetProjectByUser()
    {
        var query = new GetProjectByUserQuery();

        var project = await _mediator.Send(query);

        return Ok(project);
    }

    /// <summary>
    /// Create new project (Admin)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Post/CreateProject
    ///     {
    ///         "Title":"Super mario",
    ///         "OwnerId":"08869D6C-E1F5-4FEC-BA5A-7C50178DC99A",
    ///         "DateStart": "01/03/2024",
    ///         "DateEnd": "02/03/2024",
    ///     } 
    /// 
    /// </remarks>
    /// <param name="model"></param>
    /// <returns>Id created project</returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Validations error</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), 400)]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDTO model)
    {
        var command = new CreateProjectCommand(model.Title, model.OwnerId, model.DateStart, model.DateEnd);

        var id = await _mediator.Send(command);

        return Ok(id);
    }

    /// <summary>
    /// Updated project (Admin)
    /// </summary>
    /// <remarks>
    /// RequestType:
    ///
    ///     Put/UpdateProject
    ///     {
    ///         "ProjectId":"08869D6C-E1F5-4FEC-BA5A-7C50178DC99A",
    ///         "DateStart": "01/03/2024",
    ///         "DateEnd": "02/03/2024",
    ///         "Status":"Stuck",
    ///         "OwnerId":"49BC8754-3DF8-4BA6-8710-80418DA32887",
    ///         "Title":"Super mario 2",
    ///     }
    /// 
    /// </remarks>
    /// <param name="model"></param>
    /// <returns>Updated project</returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Validation errors</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    /// <response code="404">Project is not found</response>
    [HttpPut]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ProjectViewModel), 200)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), 400)]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectDTO model)
    {
        var command = new UpdateProjectCommand(model.ProjectId, model.DateStart, model.DateEnd, model.Status,
            model.OwnerId, model.Title);

        var updatedProject = await _mediator.Send(command);

        return Ok(updatedProject);
    }

    /// <summary>
    /// Delete project (Admin)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Delete/DeleteProject?projectId=B156D35F-3506-4440-A27C-ADA151BDA7F9
    /// 
    /// </remarks>
    /// <param name="projectId"></param>
    /// <returns>No Content</returns>
    /// <response code="200">No content</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    /// <response code="404">Project is not found</response>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> DeleteProject(Guid projectId)
    {
        var command = new DeleteProjectCommand(projectId);

        await _mediator.Send(command);

        return NoContent();
    }
}