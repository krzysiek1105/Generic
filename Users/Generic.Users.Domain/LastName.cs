using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public class LastName : ValueObject
{
    public const int MinLength = 2;
    public const int MaxLength = 50;
    public string Value { get; }

    public LastName(string lastName)
    {
        ArgumentNullException.ThrowIfNull(lastName, nameof(lastName));

        if (string.IsNullOrEmpty(lastName))
        {
            throw new DomainException("Last name is empty");
        }

        if (lastName.Length < MinLength)
        {
            throw new DomainException($"Last name must be at least {MinLength} characters long");
        }

        if (lastName.Length > MaxLength)
        {
            throw new DomainException($"Last name must be at most {MaxLength} characters long");
        }

        if (!lastName.All(char.IsLetter))
        {
            throw new DomainException($"Last name must be only letters");
        }

        Value = lastName;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value.ToUpper();
    }
}