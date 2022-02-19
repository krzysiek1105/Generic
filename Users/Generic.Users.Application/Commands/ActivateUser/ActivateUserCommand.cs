using Generic.Shared.Application;
using Generic.Shared.Application.FailureReasons;
using Generic.Users.Application.Commands.ActivateUser.FailureReasons;
using Generic.Users.Domain;

namespace Generic.Users.Application.Commands.ActivateUser;

internal class ActivateUserCommand : CommandHandlerBase<ActivateUserRequest, ActivateUserCommandResult>
{
    private readonly IUserRepository _userRepository;

    public ActivateUserCommand(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<ICommandResult<ActivateUserCommandResult>> Handle(ActivateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.UserId);
        if (user == null)
        {
            return Failure(new UserDoesNotExist(request.UserId));
        }

        try
        {
            user.Activate(request.ActivationToken);
        }
        catch (UserActivationException)
        {
            return Failure(new UserActivationFailed(request.UserId, request.ActivationToken));
        }

        await _userRepository.SaveChanges();
        return Success(new ActivateUserCommandResult
        {
            IsActivated = true,
            UserId = user.Id
        });
    }
}