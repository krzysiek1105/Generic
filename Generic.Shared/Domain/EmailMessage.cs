namespace Generic.Shared.Domain;

public class EmailMessage : ValueObject
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

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return From;
        yield return To;
        yield return Subject;
        yield return Body;
    }
}