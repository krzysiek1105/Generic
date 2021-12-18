namespace Generic.Shared.Domain;

public class Email : ValueObject
{
    public string Value { get; }

    public Email(string value)
    {
        Value = value;
    }
}