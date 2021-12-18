using Generic.Users.Application.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Generic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommandRequest createUserCommandRequest, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(createUserCommandRequest, cancellationToken));
    }
}