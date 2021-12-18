namespace Generic.Shared.Domain;

public interface IEmailSender
{
    void Send(EmailMessage emailMessage);
}