using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public class FirstName : ValueObject
{
    public const int MinLength = 2;
    public const int MaxLength = 50;
    public string Value { get; }

    public FirstName(string firstName)
    {
        ArgumentNullException.ThrowIfNull(firstName, nameof(firstName));

        if (string.IsNullOrEmpty(firstName))
        {
            throw new DomainException("First name is empty");
        }

        if (firstName.Length < MinLength)
        {
            throw new DomainException($"First name must be at least {MinLength} characters long");
        }

        if (firstName.Length > MaxLength)
        {
            throw new DomainException($"First name must be at most {MaxLength} characters long");
        }

        if (!firstName.All(char.IsLetter))
        {
            throw new DomainException($"First name must be only letters");
        }

        Value = firstName;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value.ToUpper();
    }
}