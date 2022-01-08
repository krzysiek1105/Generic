﻿using System.Net;
using Generic.Categories.Application.Commands.CreateCategory;
using Generic.Users.Application.Commands.CreateUser;
using Generic.Users.Application.Queries.GetUser;
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
    [ProducesResponseType(typeof(CreateUserCommandResult), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create(CreateUserCommandRequest createUserCommandRequest, CancellationToken cancellationToken)
    {
        var createUserCommandResult = await _mediator.Send(createUserCommandRequest, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = createUserCommandResult.Id }, createUserCommandResult);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetUserQueryRequest { Id = id }, cancellationToken));
    }

    [HttpPost("categories")]
    public async Task<IActionResult> Create(CreateCategoryCommandRequest createCategoryCommandRequest, CancellationToken cancellationToken)
    {
        var createUserCommandResult = await _mediator.Send(createCategoryCommandRequest, cancellationToken);
        if (!createUserCommandResult.Successful)
        {
            return BadRequest(createUserCommandResult.ErrorMessages);
        }

        var result = createUserCommandResult.Result;
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }
}