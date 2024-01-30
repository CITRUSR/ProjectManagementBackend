using Application.Auth.User.Commands.RegisterUser;
using Application.Auth.User.Queries.LoginUser;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.User;

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
    ///         "Password": "12345QWasg",
    ///     }
    /// 
    /// </remarks>
    /// <param name="model"></param>
    /// <returns>Return jwt token</returns>
    /// <response code="200">Return jwt token</response>
    /// <response code="400">Return validation exceptions</response>
    /// <response code="404">Return if user not found</response>
    /// <response code="500">Return if identity error or some other</response>
    [HttpPost]
    [ProducesResponseType(typeof(string),200)]
    [ProducesResponseType(typeof(IEnumerable<ValidationFailure>),400)]
    [ProducesResponseType(typeof(string),404)]
    [ProducesResponseType(typeof(IEnumerable<IdentityError>),500)]
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
    /// <response code="400">Return if validation exceptions</response>
    /// <response code="500">Return if identity error or some other</response>
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<ValidationFailure>),400)]
    [ProducesResponseType(typeof(IEnumerable<IdentityError>),500)]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO model)
    {
        var command = new RegisterUserCommand(model.Login, model.Password, model.ConfirmPassword);

        await Mediator.Send(command);

        return NoContent();
    }
}