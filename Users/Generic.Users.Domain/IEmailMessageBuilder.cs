using Generic.Shared.Domain;

namespace Generic.Users.Domain;

internal interface IEmailMessageBuilder
{
    EmailMessage CreateWelcomeMessage(User user);
    EmailMessage CreateResetPasswordMessage(User user);
}