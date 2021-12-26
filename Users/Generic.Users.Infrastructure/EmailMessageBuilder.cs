using Generic.Shared.Domain;
using Generic.Users.Domain;

namespace Generic.Users.Infrastructure;

internal class EmailMessageBuilder : IEmailMessageBuilder
{
    public EmailMessage CreateWelcomeMessage(User user)
    {
        var from = new Email("example@example.com");
        return new EmailMessage(from, user.Email, "Welcome", "Hello!");
    }

    public EmailMessage CreateResetPasswordMessage(User user)
    {
        var from = new Email("example@example.com");
        return new EmailMessage(from, user.Email, "Reset password", "Hello!");
    }
}