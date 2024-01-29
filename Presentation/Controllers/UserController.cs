using Application.Auth.User.Commands.RegisterUser;
using Application.Auth.User.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.User;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO model)
    {
        var query = new LoginUserQuery(model.Login, model.Password);

        string jwt = await Mediator.Send(query);

        return Ok(jwt);
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO model)
    {
        var command = new RegisterUserCommand(model.Login, model.Password, model.ConfirmPassword);

        await Mediator.Send(command);

        return Ok();
    }
}