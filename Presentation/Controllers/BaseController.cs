using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.Controllers;

public class BaseController : ControllerBase
{
    protected readonly IMediator Mediator;

    protected Guid UserId => User.Identity.IsAuthenticated
        ? Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
        : Guid.Empty;

    public BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
}