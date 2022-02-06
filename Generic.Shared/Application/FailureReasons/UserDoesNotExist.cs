namespace Generic.Shared.Application.FailureReasons;

public class UserDoesNotExist : ICommandFailureReason
{
    private readonly Guid _userId;

    public UserDoesNotExist(Guid userId)
    {
        _userId = userId;
    }

    public string Description => $"User '{_userId}' does not exist";
}