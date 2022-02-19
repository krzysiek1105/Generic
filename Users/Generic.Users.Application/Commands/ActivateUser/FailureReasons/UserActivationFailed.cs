using Generic.Shared.Application;

namespace Generic.Users.Application.Commands.ActivateUser.FailureReasons;

internal class UserActivationFailed : ICommandFailureReason
{
    private readonly Guid _userId;
    private readonly Guid _activationToken;

    public UserActivationFailed(Guid userId, Guid activationToken)
    {
        _userId = userId;
        _activationToken = activationToken;
    }

    public string Description => $"Failed to activate user '{_userId} with token '{_activationToken}'";
}