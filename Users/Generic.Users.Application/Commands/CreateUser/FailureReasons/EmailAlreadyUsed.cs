using Generic.Shared.Application;

namespace Generic.Users.Application.Commands.CreateUser.FailureReasons;

internal class EmailAlreadyUsed : ICommandFailureReason
{
    private readonly string _email;

    public EmailAlreadyUsed(string email)
    {
        _email = email;
    }

    public string Description => $"Email '{_email}' is already in use";
}