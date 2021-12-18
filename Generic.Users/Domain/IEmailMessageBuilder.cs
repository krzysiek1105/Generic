using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public interface IEmailMessageBuilder
{
    EmailMessage CreateWelcomeMessage(User user);
    EmailMessage CreateResetPasswordMessage(User user);
}