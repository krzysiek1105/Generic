using Generic.Shared.Application;
using MediatR;

namespace Generic.Users.Application.Commands.ActivateUser;

internal class ActivateUserRequest : IRequest<ICommandResult<ActivateUserCommandResult>>
{
    public Guid UserId { get; set; }
    public Guid ActivationToken { get; set; }
}