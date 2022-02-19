using Generic.Shared.Application;
using MediatR;

namespace Generic.Users.Application.Commands.RegisterUser;

public class RegisterUserCommandRequest : IRequest<ICommandResult<RegisterUserCommandResult>>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}