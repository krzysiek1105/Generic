namespace Generic.Users.Application.Commands.ActivateUser;

internal class ActivateUserCommandResult
{
    public Guid UserId { get; set; }
    public bool IsActivated { get; set; }
}