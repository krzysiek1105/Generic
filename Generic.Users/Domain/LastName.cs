using Generic.Shared.Domain;

namespace Generic.Users.Domain;

internal class LastName : ValueObject
{
    public string Value { get; }

    public LastName(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}