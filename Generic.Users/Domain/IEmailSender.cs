using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public interface IEmailSender
{
    void Send(EmailMessage emailMessage);
}