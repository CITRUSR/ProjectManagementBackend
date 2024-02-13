using Application.Auth.User;
using Application.Auth.User.Commands.RegisterConfirmUser;
using Application.Auth.User.Commands.RegisterUser;
using Application.Auth.User.Queries.GetAllUsers;
using Application.Auth.User.Queries.LoginUser;
using Application.Common.Exceptions;
using Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.User;
using Task = Domain.Task;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(IMediator mediator) : BaseController(mediator)
{
    /// <summary>
    /// LoginUser
    /// </summary>
    /// <remarks>
    /// Request type:
    /// 
    ///     Post/LoginUser
    ///     {  
    ///         "Login": "User",
    ///         "Password": "12345QWasg!",
    ///     }
    /// 
    /// </remarks>
    /// <param name="model"></param>
    /// <returns>Return jwt token</returns>
    /// <response code="200">Return jwt token</response>
    /// <response code="400">Return validation exceptions</response>
    /// <response code="404">Return if user not found</response>♦
    /// <response code="401">Return if identity error</response>
    [HttpPost]
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), 400)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(typeof(IEnumerable<IdentityError>), 401)]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO model)
    {
        var query = new LoginUserQuery(model.Login, model.Password);

        string jwt = await Mediator.Send(query);

        return Ok(jwt);
    }

    /// <summary>
    /// Registration user
    /// </summary>
    /// <remarks>
    /// Request type:
    /// 
    ///     Post/RegisterUser
    ///     {
    ///         "Login": "User",
    ///         "Password": "12345qwerty",
    ///         "ConfirmPassword": "12345qwerty"
    ///     }
    /// 
    /// </remarks>
    /// <param name="model"></param>
    /// <returns>No Content</returns>
    /// <response code="200">No Content</response>
    /// <response code="400">Validation errors</response>
    /// <response code="401">Identity error</response>
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), 400)]
    [ProducesResponseType(typeof(IEnumerable<IdentityError>), 401)]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO model)
    {
        var command = new RegisterUserCommand(model.Login, model.Position, model.Password, model.ConfirmPassword);

        await Mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Confirm the registration request (Admin)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Post/RegisterConfirmUser
    ///     {
    ///         "Id":"443697EF-7BCE-4118-B4F6-68A6AF477683"
    ///         "Position":"It"
    ///     }
    /// 
    /// </remarks>
    /// <param name="model"></param>
    /// <returns>Ok</returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Validations error</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    /// <response code="404">User not found</response>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), 400)]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<IActionResult> RegisterConfirmUser([FromBody] RegisterConfrimUserDTO model)
    {
        var command = new RegisterConfirmUserCommand(model.Id, model.Position);

        await Mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Get all users (Admin)
    /// </summary>
    /// <remarks>
    /// Request type:
    ///
    ///     Get/GetAllUsers
    /// 
    /// </remarks>
    /// <returns>Ok</returns>
    /// <response code="200">Ok</response>
    /// <response code="401">User is not authorized</response>
    /// <response code="403">User doesn't have the necessary rights</response>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(List<UserViewModel>), 200)]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();

        var users = await Mediator.Send(query);

        return Ok(users);
    }
}