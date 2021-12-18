using Generic.Shared.Domain;
using Generic.Users.Domain;

namespace Generic.Users.Infrastructure
{
    internal class EmailMessageBuilder : IEmailMessageBuilder
    {
        public EmailMessage CreateWelcomeMessage(User user)
        {
            return null;
        }

        public EmailMessage CreateResetPasswordMessage(User user)
        {
            return null;
        }
    }
}
