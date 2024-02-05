using Application.Common.Exceptions;
using Application.Task;
using Application.Task.Commands.CreateTask;
using Application.Task.Commands.DeleteTask;
using Application.Task.Commands.UpdateTask;
using Application.Task.Queries.GetAllTasks;
using Application.Task.Queries.GetTaskById;
using Application.Task.Queries.GetTasksByProject;
using Application.Task.Queries.GetTasksByUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Task;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TaskController(IMediator mediator) : BaseController(mediator)
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Get all tasks from all projects (Admin)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Get/GetAllTasks
    /// 
    /// </remarks>
    /// <returns>Ok</returns>
    /// <response code="200">Ok</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(List<TaskViewModel>), 200)]
    public async Task<IActionResult> GetAllTasks()
    {
        var query = new GetAllTasksQuery();

        var tasks = await _mediator.Send(query);

        return Ok(tasks);
    }

    /// <summary>
    /// Get task by id
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Get/GetTaskById?id=2774BF9E-BB3F-430F-8DED-94CD839390A3
    /// 
    /// </remarks>
    /// <param name="id"></param>
    /// <returns>Ok</returns>
    /// <response code="200">Ok</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="404">Task is not found</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(TaskViewModel), 200)]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var query = new GetTaskByIdQuery(id);

        var task = await _mediator.Send(query);

        return Ok(task);
    }

    /// <summary>
    /// Get all tasks from project (Admin, ProjectManager)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Get/GetTasksByProject?projectId=B3822712-4A09-46B3-BD26-9DB66951AB95
    /// 
    /// </remarks>
    /// <param name="projectId"></param>
    /// <returns>Ok</returns>
    /// <response code="200">Ok</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    [HttpGet]
    [Authorize(Roles = "Admin,ProjectManager")]
    [ProducesResponseType(typeof(List<TaskViewModel>), 200)]
    public async Task<IActionResult> GetTasksByProject(Guid projectId)
    {
        var query = new GetTasksByProjectQuery(projectId);

        var tasks = await _mediator.Send(query);

        return Ok(tasks);
    }

    /// <summary>
    /// Get all tasks from user
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Get/GetTasksByUser?ownerId=B71DC540-169F-4F36-A1CA-7A825877428C
    /// 
    /// </remarks>
    /// <param name="ownerId"></param>
    /// <returns>Ok</returns>
    /// <response code="200">Ok</response>
    /// <response code="401">User is not authorized</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(List<TaskViewModel>), 200)]
    public async Task<IActionResult> GetTasksByUser(Guid ownerId)
    {
        var query = new GetTasksByUserQuery(ownerId);

        var task = await _mediator.Send(query);

        return Ok(task);
    }

    /// <summary>
    /// Create task (Admin, ProjectManager)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Post/CreateTask
    ///     {
    ///         "ProjectId":"0B3CD484-B683-4DF6-98BB-377FA8764893",
    ///         "OwnerId":"4AB492D5-08EB-4E0E-83DB-7CC2E8EFA514",
    ///         "Title":"Add music",
    ///         "Status":"Created",
    ///         "Priority":"Medium",
    ///         "DateStart":"01/03/2024",
    ///         "DateEnd":"01/05/2024",
    ///     }
    /// 
    /// </remarks>
    /// <param name="model"></param>
    /// <returns>Ok</returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Validation errors</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    [HttpPost]
    [Authorize(Roles = "Admin,ProjectManager")]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), 400)]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDTO model)
    {
        var command = new CreateTaskCommand(model.ProjectId, model.OwnerId, model.Title, model.Status, model.Priority,
            model.DateStart, model.DateEnd);

        var createdTaskId = await _mediator.Send(command);

        return Ok(createdTaskId);
    }

    /// <summary>
    /// Update task (Admin, ProjectManager)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Post/UpdateTask
    ///     {
    ///         "Id":"A945B963-88CA-43EB-8D9C-8128AE6A13E7",
    ///         "OwnerId":"4AB492D5-08EB-4E0E-83DB-7CC2E8EFA514",
    ///         "Title":"Add animations",
    ///         "Status":"Created",
    ///         "Priority":"Medium",
    ///         "DateStart":"01/03/2024",
    ///         "DateEnd":"01/05/2024",
    ///     }
    /// 
    /// </remarks>
    /// <param name="model"></param>
    /// <returns>Ok</returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Validation errors</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    /// <response code="404">Task is not found</response>
    [HttpPost]
    [Authorize(Roles = "Admin,ProjectManager")]
    [ProducesResponseType(typeof(TaskViewModel), 200)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), 400)]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskDTO model)
    {
        var command = new UpdateTaskCommand(model.Id, model.OwnerId, model.Title, model.Status, model.Priority,
            model.DateStart, model.DateEnd);

        var updatedTask = await _mediator.Send(command);

        return Ok(updatedTask);
    }

    /// <summary>
    /// Delete task by id (Admin, ProjectManager)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Post/DeleteTask?id=4584023F-7E8F-4256-B1DC-24E9036C3ADC
    /// 
    /// </remarks>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">No Content</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    /// <response code="404">task is not found</response>
    [HttpPost]
    [Authorize(Roles = "Admin,ProjectManager")]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        var command = new DeleteTaskCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}