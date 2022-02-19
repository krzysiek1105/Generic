using Generic.Categories.Application.Commands.CreateCategory;
using Generic.Users.Application.Commands.RegisterUser;
using Generic.Users.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
    [ProducesResponseType(typeof(RegisterUserCommandResult), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create(RegisterUserCommandRequest registerUserCommandRequest, CancellationToken cancellationToken)
    {
        var createUserCommandResult = await _mediator.Send(registerUserCommandRequest, cancellationToken);
        if (!createUserCommandResult.Successful)
        {
            return BadRequest(createUserCommandResult, "Failed to create an user");
        }

        var result = createUserCommandResult.Result;
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var getUserQueryRequest = await _mediator.Send(new GetUserQueryRequest { Id = id }, cancellationToken);
        if (!getUserQueryRequest.Successful)
        {
            return NotFound(getUserQueryRequest, $"User with id {id} does not exist");
        }

        return Ok(getUserQueryRequest.Result);
    }

    [HttpPost("categories")]
    public async Task<IActionResult> Create(CreateCategoryCommandRequest createCategoryCommandRequest, CancellationToken cancellationToken)
    {
        var createUserCommandResult = await _mediator.Send(createCategoryCommandRequest, cancellationToken);
        if (!createUserCommandResult.Successful)
        {
            return BadRequest(createUserCommandResult, "Failed to create a category");
        }

        var result = createUserCommandResult.Result;
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }
}