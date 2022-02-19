using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public class FirstName : ValueObject
{
    public string Value { get; }

    public FirstName(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}