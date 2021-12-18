namespace Generic.Shared.Domain;

public class EmailMessage
{
    public EmailMessage(Email @from, Email to, string subject, string body)
    {
        From = @from;
        To = to;
        Subject = subject;
        Body = body;
    }

    public Email From { get; }
    public Email To { get; }
    public string Subject { get; }
    public string Body { get; }
}