using Generic.Shared.Application;
using Generic.Shared.Application.FailureReasons;
using Generic.Users.Application.Commands.ActivateUser.FailureReasons;
using Generic.Users.Domain;
using MediatR;

namespace Generic.Users.Application.Commands.ActivateUser;

internal class ActivateUserCommand : IRequestHandler<ActivateUserRequest, ICommandResult<ActivateUserCommandResult>>
{
    private readonly IUserRepository _userRepository;

    public ActivateUserCommand(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ICommandResult<ActivateUserCommandResult>> Handle(ActivateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.UserId);
        if (user == null)
        {
            return new CommandResult<ActivateUserCommandResult>().AddFailureReason(new UserDoesNotExist(request.UserId));
        }

        try
        {
            user.Activate(request.ActivationToken);
        }
        catch (UserActivationException)
        {
            return new CommandResult<ActivateUserCommandResult>().AddFailureReason(new UserActivationFailed(request.UserId, request.ActivationToken));
        }

        await _userRepository.SaveChanges();
        return new CommandResult<ActivateUserCommandResult>().SetResult(new ActivateUserCommandResult
        {
            IsActivated = true,
            UserId = user.Id
        });
    }
}