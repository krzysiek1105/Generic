using MediatR;

namespace Generic.Users.Application.Commands.CreateUser;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResult>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}