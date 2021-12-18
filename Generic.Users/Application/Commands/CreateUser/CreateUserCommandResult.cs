﻿using Generic.Shared.Application;

namespace Generic.Users.Application.Commands.CreateUser;

public class CreateUserCommandResult : ICommandResult
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}